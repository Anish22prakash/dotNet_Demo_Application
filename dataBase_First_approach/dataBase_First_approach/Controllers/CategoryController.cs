using dataBase_First_approach.Models;
using dataBase_First_approach.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dataBase_First_approach.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _catService;

        CategoryController(ICategoryService categoryService)
        {
          _catService = categoryService;
        }

        [HttpPost]
        public IActionResult createCategory(CategoryDto category)
        {
            CategoryDto ct = _catService.PostCategory(category);

            if(ct!=null)
            {
                return Ok(ct);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
