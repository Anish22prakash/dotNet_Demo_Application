using dataBase_First_approach.Models;

namespace dataBase_First_approach.Service
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
        public Category GetCategory(int id);
        public CategoryDto PostCategory(CategoryDto category);

        public String deleteCategory(int id);
        
    }
}
