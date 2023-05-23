using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category.DataBaseContext;
using Product_Category.Model;

namespace Product_Category.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly MyDataBase _dataBase;

        public WishListController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpPost]
        public IActionResult createWishList(WishList ws) { 
        
          WishList wishList = new WishList();
            wishList.ProductId = ws.ProductId;
            wishList.CustomerId = ws.CustomerId;

            _dataBase.wishList.Add(wishList);
            _dataBase.SaveChanges();

            return Ok(" added to wishList");
        }

        [HttpDelete]
        public IActionResult deleteWishList(int id)
        {
            var res = new WishList() { WishListId = id };
            _dataBase.wishList.Remove(res);
            _dataBase.SaveChanges();

            return Ok("item is deleted");

        }
    }
}
