using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations {
  public class ReportsService : IReportsService {
    // сервис по работе с заказами
    private IOrdersService ordersService;

    // сервис по работе с блюдами
    private IDishesService dishesService;

    public ReportsService(IOrdersService ordersService, IDishesService dishesService) {
      this.ordersService = ordersService;
      this.dishesService = dishesService;
    }


    public List<OrderReportItemBO> GetOrders() {
      // Получаем список заказов
      List<OrderBO> orderBOs = ordersService.GetOrders();

      // созда1м результирующую переменную
      List<OrderReportItemBO> result = new List<OrderReportItemBO>();
      foreach (var orderBO in orderBOs) {
        // на каждом шаге находим Dish, чтобы взять из него наименование
        DishBO? dish = dishesService.GetById(orderBO.DishId);
        if (dish == null) {
          throw new Exception("Dish not found");
        }

        // создаём новый объект и заполняем свойства объекта
        OrderReportItemBO item = new OrderReportItemBO();
        item.Date = orderBO.OpenDate.Date;
        item.Sum = orderBO.Sum;
        item.DishName = dish.Name;

        // добавляем в результирующую переменную
        result.Add(item);
      }

      return result;
    }

    public List<OrderReportItemBO> GetOrders(DateTime from) {
      // Получаем список заказов с .. по ..
      List<OrderBO> orderBOs = ordersService.GetOrders(from, DateTime.Now);

      // созда1м результирующую переменную
      List<OrderReportItemBO> result = new List<OrderReportItemBO>();
      foreach (var orderBO in orderBOs) {

        // на каждом шаге находим Dish, чтобы взять из него наименование
        DishBO? dish = dishesService.GetById(orderBO.DishId);
        if (dish == null) {
          throw new Exception("Dish not found");
        }

        // создаём новый объект и заполняем свойства объекта
        OrderReportItemBO item = new OrderReportItemBO();
        item.Date = orderBO.OpenDate.Date;
        item.Sum = orderBO.Sum;
        item.DishName = dish.Name;

        // добавляем в результирующую переменную
        result.Add(item);
      }

      return result;
    }

    public List<SalesByDayOfWeekBO> GetSalesByDayOfWeek() {
      List<OrderReportItemBO> orders = GetOrders(DateTime.Now.AddDays(-7));

      List<SalesByDayOfWeekBO> result = new List<SalesByDayOfWeekBO>();

      foreach(var order in orders) {
        SalesByDayOfWeekBO item = new SalesByDayOfWeekBO();
        item.DishName = order.DishName;
        item.Date = order.Date;
        item.DayName = order.Date.ToString("dddd");
        item.Count = 1;
        if(result.FirstOrDefault(x => x.DayName == item.DayName) != null) {
          result[result.FindIndex(x => x.DayName == item.DayName)].Count += 1;
        }
        else {
          result.Add(item);
        }
      }

      return result;
    }

    public List<OrderReportItemBO> GetOrders(DateTime from, DateTime to) {
      // Получаем список заказов с .. по ..
      List<OrderBO> orderBOs = ordersService.GetOrders(from, to);

      // созда1м результирующую переменную
      List<OrderReportItemBO> result = new List<OrderReportItemBO>();
      foreach (var orderBO in orderBOs) {

        // на каждом шаге находим Dish, чтобы взять из него наименование
        DishBO? dish = dishesService.GetById(orderBO.DishId);
        if (dish == null) {
          throw new Exception("Dish not found");
        }

        // создаём новый объект и заполняем свойства объекта
        OrderReportItemBO item = new OrderReportItemBO();
        item.Date = orderBO.OpenDate.Date;
        item.Sum = orderBO.Sum;
        item.DishName = dish.Name;

        // добавляем в результирующую переменную
        result.Add(item);
      }

      return result;
    }
  }
}
