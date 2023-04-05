using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface Iorder
    {
        Order Add(Order Data);

        List<Order> GetById(int id);

        List<Order> Get();
    }
}
