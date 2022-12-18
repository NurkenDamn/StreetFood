using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.IoC;
using StreetFood.BusinessLogic.Interfaces;

IReportsService reportsService = IoC.GetReportsService();
IOrdersService ordersService = IoC.GetOrderService();

ordersService.AddOrder(new OrderBO() { DishId = 1, OpenDate = DateTime.Now, Sum = 450 });

var salesByDayOfWeekBO = reportsService.GetSalesByDayOfWeek();

foreach(var item in salesByDayOfWeekBO) {
  Console.WriteLine($@"{item.DishName} | {item.DayName} | {item.Count}");
}

Console.ReadLine();