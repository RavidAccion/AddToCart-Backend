﻿using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface Iproducts
    {
        Product Add(Product Data);

        List<Product> Get();



        List<Product> Getbycategory(int category);
    }
}
