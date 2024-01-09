using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Hackathon_MV.Server.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        
        private readonly IMapper _mapper;

        public AuthRepository(DataContext context, IConfiguration configuration, IMapper mapper
        )
        {
            _context = context;
            _configuration = configuration;
            
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();

            if (await UserExists(user.Email))
            {
                response.Success = false;
                response.Message = "User Already Exists";
                return response;
            }

            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public  async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect Password";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }


        public async Task<ServiceResponse<GetUserDto>> GetUserByToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            var response = new ServiceResponse<GetUserDto>();
            

            if (appSettingsToken == null)
            {
                throw new Exception("AppSettings token is null");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsToken));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false,
                // You may want to set other parameters based on your requirements
            };

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)!.Value);
                var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                response.Data = _mapper.Map<GetUserDto>(dbUser);


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Cant find user";

            }

            return response;

        }




        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower()))
            {
                return true;
            }

            return false;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;

            if (appSettingsToken == null)
            {
                throw new Exception("AppSettings token is null");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

          return  tokenHandler.WriteToken(token);

            
        }

       
    }
}
