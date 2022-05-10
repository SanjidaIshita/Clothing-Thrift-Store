using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thrifty.Areas.Identity.Data;
using Thrifty.Models;

namespace Thrifty.Data
{
    public class ThriftyDataContext : IdentityDbContext<ThriftyUser>
    {
        public ThriftyDataContext(DbContextOptions<ThriftyDataContext> options)
            : base(options)
        {     
        }
        public DbSet<Products> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<ThriftyUser> ThriftyUser { get; set; }
        public object AspNetUsers { get; internal set; }
    }
}
