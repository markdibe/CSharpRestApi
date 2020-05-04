using CustomerAppDAO;
using CustomerAppDAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAO.Context
{
    public class InMemoryContext :DbContext 
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //options that we want in memory
        public InMemoryContext():base(options) 
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
