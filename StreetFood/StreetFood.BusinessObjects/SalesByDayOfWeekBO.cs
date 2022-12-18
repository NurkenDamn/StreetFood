using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessObjects {
  public class SalesByDayOfWeekBO {
    public string DishName { get; set; }
    public DateTime Date { get; set; }
    public string DayName { get; set; }
    public int Count { get; set; }
  }
}
