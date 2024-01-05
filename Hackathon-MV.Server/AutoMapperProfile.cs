﻿using AutoMapper;

namespace Hackathon_MV.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDTO>();

            CreateMap<AddUserDTO, User>();
        }
        
    }
}
