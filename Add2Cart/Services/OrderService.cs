using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;

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

        public List<Order> Get()
        {
            return dataContext.orders.ToList();
        }

        public List<Order> GetById(int id)
        {
            var List = dataContext.orders.ToList();
            List<Order> data1 = new List<Order>();
            foreach (var item in List)
            {
                if (item.cus_id == id)
                    data1.Add(item);
            }



            return data1;
        }
    }
}
