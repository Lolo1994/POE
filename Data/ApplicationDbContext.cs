using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task_2.Models;

namespace Task_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Task_2.Models.MoneyDonations> MoneyDonations { get; set; }
        public DbSet<Task_2.Models.DisasterType> DisasterType { get; set; }
        public DbSet<Task_2.Models.GoodsDonations> GoodsDonations { get; set; }
        public DbSet<Task_2.Models.GoodsCategories> GoodsCategories { get; set; }
        public DbSet<Task_2.Models.DiasterAllocation> DiasterAllocation { get; set; }
        public DbSet<Task_2.Models.GoodsAllocation> GoodsAllocation { get; set; }
       // public DbSet<Task_2.BudgetAllocation> BudgetAllocation { get; set; }
    }
}
