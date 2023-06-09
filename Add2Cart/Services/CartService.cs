﻿using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;

namespace Add2Cart.Services
{
    public class CartService : Icart
    {
        private readonly DataBase dataContext;
        public CartService(DataBase dbContext)
        {
            dataContext = dbContext;
        }
        public Cart AddCartData(Cart Data)
        {
            dataContext.cart_data.Add(Data);
            dataContext.SaveChanges();

            return Data;
        }

        public List<Cart> Get()
        {
            return dataContext.cart_data.ToList();
        }

        public Cart Getcart(int Id)
        {
            var data2 = dataContext.cart_data.Find(Id);

            return data2;
        }
        public DeleteResultSet DeleteCart(Cart data)
            
        {
            var resultdata = new DeleteResultSet();
            if (data != null)
            {
                dataContext.Remove(data);
                dataContext.SaveChanges();
                resultdata.status = true;
                resultdata.result = "Item deleted Successfully";

            }
            return resultdata;
        }
        List<Cart> Icart.Getbycart(int id)
        {
            var List = dataContext.cart_data.ToList();
            List<Cart> data1 = new List<Cart>();
            foreach (var item in List)
            {
                if (item.customer_id == id)
                    data1.Add(item);
            }
         


            return data1;
        }
    }
}
