using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Data.Model;
using System.Linq;

namespace App.Data.DB
{
    public class RestaurantsContext : DbContext
    {
        public string connectPath { get; set; }


        public RestaurantsContext() 
        {
            connectPath = @"server=leo-arthaud-pc\SQLSERVE;database=DbAspNet;trusted_connection=true;";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectPath);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
