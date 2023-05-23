using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly MyDataBase _dataBase;

        public ProductController(MyDataBase dataBase)
        {
          _dataBase = dataBase;
        }

        [HttpGet]

        public List<Products> getAllProducts() { 
        
            return _dataBase.products.ToList();
        }

        [HttpGet]
        public ActionResult getProductById(int id)
        {
            var result = _dataBase.products.Where(x => x.ProductId == id).Select(x => new Products()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                CreatedDate=x.CreatedDate
            });

            return Ok(result);
        }
        [HttpPost]

        public String createProduct(ProductDto prt)
        {
            Products products = new Products();
            products.ProductName = prt.ProductName;
            products.CreatedDate = DateTime.Now;
            products.CategoryId= prt.CategoryId;

            _dataBase.products.Add(products);
            _dataBase.SaveChanges();

            return "product is created";
        }

        [HttpDelete]
        public String deleteProduct(int id) 
        {
           var product = new Products() { ProductId = id };
            _dataBase.products.Remove(product);
                _dataBase.SaveChanges();

            return "product is removed";
        }

        [HttpPut]
        public String updateProduct(int id , ProductDto prt)
        {
            var product = new Products()
            {
                ProductId = id,
                ProductName = prt.ProductName,
                CategoryId = prt.CategoryId,
                CreatedDate = DateTime.Now
            };

            _dataBase.products.Update(product);
            _dataBase.SaveChanges();

            return "product is updated";
        }


    }
}
