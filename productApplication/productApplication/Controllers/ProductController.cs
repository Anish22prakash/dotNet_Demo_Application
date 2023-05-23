using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productApplication.DataBaseContext;
using productApplication.ModelData;

namespace productApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly MyDataBase _dataBase;
        public ProductController(MyDataBase myDataBase) 
        {
            _dataBase = myDataBase;
        }

        [HttpGet]
        public IActionResult getAllProducts() {

            return Ok(_dataBase.Products.ToList());
        }

        [HttpPost]
        public IActionResult createProducts(Product pro) 
        {
            Product pt = new Product();
            pt.productName=pro.productName;
            pt.category=pro.category;
            pt.price=pro.price;

            _dataBase.Products.Add(pt);
            _dataBase.SaveChanges();

            return Ok(pro);
        }

        [HttpGet]
        public IActionResult getProductsById(int id) 
        {
          var record =  _dataBase.Products.Where(pt=>pt.id==id).Select(x => new Product()
          { 
              id = x.id,
              productName = x.productName,
              category = x.category,
              price=x.price
          });

            return Ok(record);

        }

    }
}
