using StreetFood.DAL;
using StreetFood.Entities;
using StreetFood.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Repositories.Implementations {
  public class PurchaseRepository : IPurchaseRepository {
    public void AddPurchase(Purchase purchase) {
      using(StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext()) {
        streetFoodDbContext.Purchases.Add(purchase);
        streetFoodDbContext.SaveChanges();
      }
    }
  }
}
