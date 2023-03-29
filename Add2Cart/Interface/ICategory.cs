using Add2CartModels;

namespace Add2Cart.Interface
{
    public interface ICategory
    {
      
            Category Add(Category data);

        List<Category> Get();

    }
}
