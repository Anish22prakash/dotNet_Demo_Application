using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly MyDataBase _dataBase;

        public CartController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        [HttpPost]
        public IActionResult createCart(Cart cart)
        {
            Cart cr= new Cart();
            cr.ProductId = cart.ProductId;
            cr.CustomerId = cart.CustomerId;

            _dataBase.cart.Add(cr);
            _dataBase.SaveChanges();

            return Ok("item is added into cart");
        }

        [HttpDelete]
        public IActionResult deleteCart(int id)
        {
            var cr= new Cart() { CartId = id }; 

            _dataBase.cart.Remove(cr);
            _dataBase.SaveChanges();
            return Ok("item is removed from the cart");
        }

    }
}
