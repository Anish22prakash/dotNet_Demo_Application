using dataBase_First_approach.Models;

namespace dataBase_First_approach.Service
{
    public class CategoryService : ICategoryService
    {
         DbfirstContext _dbContext;
        public CategoryService(DbfirstContext dbfirstContext) 
        {
          _dbContext = dbfirstContext;
        }
        public string deleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto PostCategory(CategoryDto category)
        {
            CategoryDto ct= new CategoryDto();
            ct.CategoryId = category.CategoryId;
            ct.CategoryName = category.CategoryName;
            try
            {
                if (ct != null)
                {
                    _dbContext.Add(ct);
                    _dbContext.SaveChanges();

                    return ct;
                }
                else {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
