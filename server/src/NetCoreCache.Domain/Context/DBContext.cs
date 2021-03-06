﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.EntityConfig;
using NetCoreCache.Domain.EntityConfig.Extensions;
using System.IO;

namespace NetCoreCache.Domain.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;            
        }

        public DbSet<Area> Area { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AreaMap());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appSettings.json")
            //    .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
