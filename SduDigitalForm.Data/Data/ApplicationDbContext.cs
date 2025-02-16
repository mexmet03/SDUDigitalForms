﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SduDigitalForm.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SduDigitalForm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(string connectionString)
           : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tbl_User> AspNetUsers { get; set; }
        public DbSet<Tbl_TypeDevice> Tbl_TypeDevices { get; set; }
        public DbSet<Tbl_OrganizationUnit> Tbl_OrganizationUnits { get; set; }
        public DbSet<Tbl_IssueType> Tbl_IssueTypes { get; set; }
        public DbSet<Tbl_Issue> Tbl_Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tbl_IssueType>(opt => opt.HasKey(x => x.Idissue));

            builder.Entity<Tbl_IssueType>(opt => 
                                opt.HasData(new Tbl_IssueType() {Idissue=1,IssueType="Ekran değişimi" }
                                )
                            );

            base.OnModelCreating(builder);
        }

       
    }
}
