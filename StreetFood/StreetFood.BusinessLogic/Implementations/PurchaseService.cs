using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations {
  public class PurchaseService : IPurchaseService {
    IPurchaseProvider purchaseProvider;
    public PurchaseService(IPurchaseProvider purchaseProvider) {
      this.purchaseProvider = purchaseProvider;
    }

    public void AddPurchase(PurchaseBO purchaseBO) {
      purchaseProvider.AddPurchase(purchaseBO);
    }
  }
}
