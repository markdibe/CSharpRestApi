using CustomerAppDAO;
using CustomerAppDAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.Context
{
    public class CustomerAppContext :DbContext 
    {
        static DbContextOptions<CustomerAppContext> options = 
            new DbContextOptionsBuilder<CustomerAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //options that we want in memory
        public CustomerAppContext():base(options) 
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

    }
}
