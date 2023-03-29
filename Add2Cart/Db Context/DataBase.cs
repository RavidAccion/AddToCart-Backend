using Add2CartModels;
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
    }
}
