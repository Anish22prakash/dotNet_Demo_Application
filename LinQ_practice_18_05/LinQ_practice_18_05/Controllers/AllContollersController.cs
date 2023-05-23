using LinQ_practice_18_05.Model;
using LinQ_practice_18_05.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinQ_practice_18_05.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AllContollersController : ControllerBase
    {

         private readonly AllService _service;
         private readonly ILogger<AllContollersController> _logger;

       
        public AllContollersController(AllService service, ILogger<AllContollersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
      
        public IActionResult createCategory(CategoryDto category)
        {
            if (category != null)
            {
                _logger.LogInformation("category is added in the database");
                string response=_service.createCategory(category);
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("bad request is hit the server");
                return BadRequest();
            }
        }
        [HttpPost]
        
        public IActionResult createProduct(ProductDto product)
        {
            _logger.LogInformation("product is creating");
            if (product != null)
            {
                string response = _service.createProduct(product);  
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("bad request is hit the server");
                return BadRequest();
            }
        }

        
        [HttpGet]
     
        public IActionResult getProductsInGroups()
        {
            try
            {
                _logger.LogInformation("getting the product in groups");
                List<ProductCategoryGroups> response = _service.getListInGroup();

                return Ok(response);
            }catch (Exception ex)
            {
                _logger.LogWarning("bad request is hit the server");
                return BadRequest();
            }
        }
        

        [HttpGet]
      
        public IActionResult getHighestPriceProduct()
        {
          Product pt= _service.getHighestPriceProdcut();
            if(pt != null)
            {
                _logger.LogInformation("getting the highest price product ");
                return Ok(pt);
            }
            else { return BadRequest(); }   
        }

        [HttpGet]
        public IActionResult getTopFiveProduct()
        {
            List<Product> list=_service.topFiveProducts();
            if(list.Count > 0)
            {
                return Ok(list);
            }else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult getSecondHighestProduct()
        {
            ProductDto pd = _service.getSecondHighestProduct();

            if (pd != null)
            {
                return Ok(pd);
            }else { return BadRequest(); }
        }


    }
}
