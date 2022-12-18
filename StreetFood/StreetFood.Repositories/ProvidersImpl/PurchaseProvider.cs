using StreetFood.Providers;
using StreetFood.Repositories.Interfaces;
using StreetFood.Entities;
using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Repositories.ProvidersImpl {
  public class PurchaseProvider : IPurchaseProvider {
    IPurchaseRepository purchaseRepository;
    public PurchaseProvider(IPurchaseRepository purchaseRepository) {
      this.purchaseRepository = purchaseRepository;
    }
    public void AddPurchase(PurchaseBO purchaseBO) {
      purchaseRepository.AddPurchase(new Purchase() {
        Id = purchaseBO.Id,
        IngredientId = purchaseBO.IngredientId,
        Count = purchaseBO.Count,
        Date = purchaseBO.Date,
        PricePerItem = purchaseBO.PricePerItem,
        Purveyor = new Partner() {
          Id = purchaseBO.Purveyor.Id,
          Address = purchaseBO.Purveyor.Address,
          BIN = purchaseBO.Purveyor.BIN,
          Name = purchaseBO.Purveyor.Name,
        },
        Comment = purchaseBO.Comment
      });
    }
  }
}
