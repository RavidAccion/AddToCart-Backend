using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface Ilogin
    {
        Login AddUser(Login Data);

        List<Login> Get();

    }
}
