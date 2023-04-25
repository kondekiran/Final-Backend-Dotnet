using EshopApplication.DBContextLayer;
using EshopApplication.Interfaces;
using EshopApplication.Models;
using EshopApplication.Models.spModel;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EshopApplication.ServiceLayer
{
    public class OrdersServices: IOrders
    {
        private readonly EshopDB eshopDB;
        public OrdersServices(EshopDB eshopDB)
        {
            this.eshopDB = eshopDB;
        }

        public List<Orders> ListOfOrders()
        {
            return eshopDB.Orders.ToList();
        }
        public Orders AddingProducts(Orders orders)
        {
            orders.OrderDate = DateTime.Now;
            eshopDB.Orders.Add(orders);
            eshopDB.SaveChanges();
            return (orders);
        }

        public List<GetOrdersByUserId> getUserOrderProducts(int userId)
        {
            return eshopDB.getOrdersByUserIds.FromSqlRaw($"spGetOrdersByUserId {userId}").ToList();
        }

     

        public Orders UpdateOrderStatus(UpdateOrders data)
        {
            var existingData = eshopDB.Orders.Find(data.orderId);
            if(existingData != null)
            {
                existingData.OrderId = data.orderId;
                existingData.UserId = existingData.UserId;
                existingData.ProductId = existingData.ProductId;
                existingData.Quantity = existingData.Quantity;
                existingData.OrderDate = existingData.OrderDate;
                existingData.OrderStatus = data.status;
                eshopDB.Update(existingData);
                eshopDB.Entry(existingData).Property(x => x.OrderId).IsModified = false;//To prevent Identity column update issue
                eshopDB.SaveChanges();
            }
            return existingData;

        }
    }
}
