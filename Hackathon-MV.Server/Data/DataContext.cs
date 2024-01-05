﻿namespace Hackathon_MV.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users = Set<User>();
    }
}