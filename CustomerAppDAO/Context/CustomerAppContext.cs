using CustomerAppDAO;
using CustomerAppDAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.Context
{
    public class CustomerAppContext : DbContext
    {
        //static DbContextOptions<CustomerAppContext> options = 
        //    new DbContextOptionsBuilder<CustomerAppContext>()
        //    .UseInMemoryDatabase("TheDB")
        //    .Options;

        ////options that we want in memory
        //public CustomerAppContext():base(options) 
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=pc-12451;database=db_csharprestapi;trusted_connection=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
    .HasKey(ca => new { ca.AddressId, ca.CustomerId });

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerId);

            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

    }
}
