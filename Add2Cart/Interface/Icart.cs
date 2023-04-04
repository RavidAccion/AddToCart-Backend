using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface Icart
    {
        Cart AddCartData(Cart Data);

        Cart Getcart(int Id);

        List<Cart> Get();
        List<Cart> Getbycart(int id);

        void DeleteCart(Cart data);
    }
}
