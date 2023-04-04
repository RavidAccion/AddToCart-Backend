using Add2CartModels;
using System.Threading.Tasks;

namespace Add2Cart.Interface
{
    public interface Icategory
    {
      
            Category Add(Category data);

        List<Category> Get();
        Category Getcategory(int Id);

        void DeleteCategory(Category data);

    }
}
