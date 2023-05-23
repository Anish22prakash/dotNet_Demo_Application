using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly MyDataBase _dataBase;

        public CategoryController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        [HttpGet]
        public List<Category> getAllCategory()
        {
            return _dataBase.categories.ToList();
        }


        [HttpGet]
        public IActionResult getCategoryById(int id)

        { 
            var result = _dataBase.categories.Where(x => x.CategoryId == id).Select(y => new Category()
            {
                CategoryId = y.CategoryId,
                CategoryName = y.CategoryName
            });

            return Ok(result);   
         }

        [HttpPost]
        public String postCategory(Category category)
        {
            Category cate = new Category();
            cate.CategoryName= category.CategoryName;

            _dataBase.categories.Add(cate);
            _dataBase.SaveChanges();

            return "category created";
        }
        [HttpPut]
        public String updateCategory(int id, Category category)
        {
            var response = new Category()
            {
                CategoryId = id,
                CategoryName = category.CategoryName
            };
            _dataBase.categories.Update(response);
            _dataBase.SaveChanges();


            return "your category is updated";

        }

        [HttpDelete]
        public String deleteCategory(int id)
        {
            var response= new Category() { CategoryId = id };
           _dataBase.categories.Remove(response);

            _dataBase.SaveChanges();

            return "your category is deleted";
        
        }
        //guid - create 16/32/64 bit  
        //
    }
}
