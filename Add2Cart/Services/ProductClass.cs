using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Add2Cart.Services
{
    public class ProductClass : Iproducts
    {
        private readonly DataBase dataContext;
        public ProductClass(DataBase dbContext)
        {
            dataContext = dbContext;
        }

        public Product Add(Product Data)
        {
            dataContext.Product.Add(Data);
            dataContext.SaveChanges();

            return Data;
        }

        public List<Product> Get()
        {
            return dataContext.Product.ToList();
        }

        public List<Product> GetProdById(int ptodID)
        {
            var List = dataContext.Product.ToList();
            List<Product> data = new List<Product>();
            foreach (var item in List)
            {
                if (item.id == ptodID)
                    data.Add(item);
            }

            return data;
        }

        List<Product> Iproducts.Getbycategory(int category)
        {
            var List = dataContext.Product.ToList();
            List<Product> data = new List<Product>();
            foreach (var item in List)
            {
                if (item.category == category)
                    data.Add(item);
            }
            var catId = category;


            return data;
        }
    }
}
