using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;

namespace Add2Cart.Services
{
    public class LoginServices : Ilogin

    {
        private readonly DataBase dataContext;
        public LoginServices(DataBase dbContext)
        {
            dataContext = dbContext;
        }

        public Login AddUser(Login Data)
        {
            dataContext.User_data.Add(Data);
            dataContext.SaveChanges();

            return Data;
        }

        public List<Login> Get()
        {
            return dataContext.User_data.ToList();
        }
    }
}
