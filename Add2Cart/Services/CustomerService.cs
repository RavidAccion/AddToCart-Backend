using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;

namespace Add2Cart.Services
{
    public class CustomerService : Icustomer
    {
        private readonly DataBase dataContext;
        public CustomerService(DataBase dbContext)
        {
            dataContext = dbContext;
        }
        public Customer AddToCustomerTable(Customer Data)
        {
            dataContext.customers.Add(Data);
            dataContext.SaveChanges();
            return Data;
        }

        public List<Customer> Get()
        {
            return dataContext.customers.ToList();
        }

        public Customer GetCustomerById(int Id)
        {
            var data = dataContext.customers.Find(Id);

            return data;
        }

        public List<Customer> GetDatasById(int id)
        {
            var List = dataContext.customers.ToList();
            List<Customer> data1 = new List<Customer>();
            foreach (var item in List)
            {
                if (item.customer_id == id)
                    data1.Add(item);
            }



            return data1;
        }
    }
}
