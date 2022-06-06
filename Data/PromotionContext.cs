using Microsoft.EntityFrameworkCore;
using ProjectPromotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPromotion.Data
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Stores> Stores { get; set; }
    }
}
