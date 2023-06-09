﻿using Add2CartModels;
using Add2CartModels.SPModels;
using Microsoft.EntityFrameworkCore;

namespace Add2Cart.Db_Context
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
       
    }
              public DbSet<Category> category { get; set; }
        
              public DbSet<Product> Product { get; set; }
              public DbSet<GetCategory> GetCategory { get;}
        
             public DbSet<Login> User_data { get; set; }
             public DbSet<Cart> cart_data { get; set; }
             public DbSet<Customer> customers { get; set; }
             public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        
            public DbSet<GetOrder> GetOrder { get; set; }
    }
}
