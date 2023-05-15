using HocLapTrinhAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HocLapTrinhAspNet.Repositorys
{
    public class OrderRepository
    {
        HocLapTrinhDbContext myDb = new HocLapTrinhDbContext();
        public void AddOrder(Order order)
        {
            myDb.Orders.Add(order);
            myDb.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var obj = myDb.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            myDb.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = myDb.Orders.Find(orderId);
            myDb.Orders.Remove(order);
            myDb.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return myDb.Orders.Find(orderId);
        }
    }
}