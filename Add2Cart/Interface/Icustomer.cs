using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface Icustomer
    {
        Customer AddToCustomerTable(Customer Data);

        Customer GetCustomerById(int Id);

        List<Customer> Get();

        List<Customer> GetDatasById(int id);
    }
}
