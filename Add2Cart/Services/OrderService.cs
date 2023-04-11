using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;
using Add2CartModels.SPModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Add2Cart.Services
{
    public class OrderService : Iorder
    {
        private readonly DataBase dataContext;
        public OrderService(DataBase dbContext)
        {
            dataContext = dbContext;
        }
        public Order Add(Order Data)
        {
            dataContext.orders.Add(Data);
            dataContext.SaveChanges();
            return Data;
        }

        public void DeleteCart(Cart data)
        {
            if (data != null)
            {
                dataContext.Remove(data);
                dataContext.SaveChanges();
            }
        }

        public List<Order> Get(int id)
        {
            var List = dataContext.orders.ToList();
            List<Order> data = new List<Order>();
            foreach (var item in List)
            {

                if (item.customer_id == id)
                    data.Add(item);
            }

            return data;

        }

        public List<Order> Get()
        {
            throw new NotImplementedException();
        }

        public List<GetOrder> GetById(int id)
        {
            /*    var List = dataContext.orders.ToList();
                List<Order> data1 = new List<Order>();
                foreach (var item in List)
                {
                    if (item.cus_id == id)
                        data1.Add(item);
                }*/
            var data= dataContext.GetOrder.FromSqlRaw($"spGetOrderDataById {id}").ToList();
            return data;
          

        }

        public Cart Getcart(int Id)
        {
           
                var data2 = dataContext.cart_data.Find(Id);
                return data2;
            
        }

        public OrderStatus updateOrder(OrderDetails data)
        {
            var result = new OrderStatus();
            var existingdata = dataContext.orders.Find(data.id);
            if (existingdata != null)
            {
                existingdata.order_status = data.status;

            }
            dataContext.orders.Update(existingdata);
            dataContext.Entry(existingdata)
                .Property(x => x.customer_id).IsModified = false; // To Prevent Idenity column update issue
            dataContext.SaveChanges();
       

                var data2 = dataContext.orders.Find(data.id);

           

            
            result.data = data2;
            return result;



        }

        public Order updateStockOrder(Order order)
        {
            var result = new OrderProductEdit();
        var data = order;
        var existingdata = dataContext.Product.Find(order.Product_id);
             if (existingdata != null)
             {

                existingdata.stock = existingdata.stock-order.stock;
             }
            dataContext.Product.Update(existingdata);
            dataContext.Entry(existingdata)
                .Property(x => x.id).IsModified = false; // To Prevent Idenity column update issue
            dataContext.SaveChanges();




    /*        var List = dataContext.orders.ToList();
            List<Order> data1 = new List<Order>();
            foreach (var item in List)
            {
                if (item.customer_id == data.cus_id)
                    data1.Add(item);
            }

*/

            return data;

        
        
    }

}
}
