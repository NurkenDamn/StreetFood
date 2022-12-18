using Microsoft.EntityFrameworkCore;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.DAL {
  public class StreetFoodDbContext : DbContext {
    public StreetFoodDbContext() {
    }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<StockProduct> StockProducts { get; set; }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Partner> Partners { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StreetFoodDb;User ID=sa;Password=SuperPassword123);Encrypt=False;");
    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StreetFood;Integrated Security=True;Encrypt=False;");
  }
}
}
