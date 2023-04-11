using Add2CartModels;
using Add2CartModels.SPModels;

namespace Add2Cart.Interface
{
    public interface Iorder
    {
        Order Add(Order Data);

        List<GetOrder> GetById(int id);

        List<Order> Get();
        Cart Getcart(int Id);

        OrderStatus updateOrder(OrderDetails data);

        public Order updateStockOrder(Order order);

        void DeleteCart(Cart data);
    }
}
