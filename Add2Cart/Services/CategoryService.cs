using Add2Cart.Db_Context;
using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Add2Cart.Services
{
    public class CategoryService : ICategory
    {
        private readonly DataBase dataContext;
        public CategoryService(DataBase dbContext)
        {
            dataContext = dbContext;
        }

        public Category Add(Category data)
        {
            dataContext.category.Add(data);
            dataContext.SaveChanges();
            return data;
        }

   

        public void DeleteCategory(Category data)
        {
            if (data != null)
            {
                dataContext.Remove(data);
                dataContext.SaveChanges();
            }
        }

    

        List<Category> ICategory.Get()
        {
            return dataContext.category.ToList();
        }

        public Category Getcategory(int Id)
        {
            var data = dataContext.category.Find(Id);

            return data;
        }
    }
}
