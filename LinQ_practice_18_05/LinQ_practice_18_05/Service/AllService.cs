using LinQ_practice_18_05.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Validations;

namespace LinQ_practice_18_05.Service
{
    public class AllService
    {
        public dataBaseContext _dataBase;

        public AllService(dataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }   

        public string createCategory(CategoryDto category)
        {
            try
            {
                Category ct = new Category();
                ct.Name = category.Name;

                _dataBase.Add(ct);
                _dataBase.SaveChanges();
                return "category is added";

            }catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public string createProduct(ProductDto product)
        {
            try
            {

              // Category ct = _dataBase.Categories.Where(x => x.Id == product.categoryId).FirstOrDefault();
                Boolean CheckCategoryId = _dataBase.Categories.Contains(new Category { Id = product.categoryId });
                if(CheckCategoryId)
                {
                    Product pt = new Product();
                    pt.Name = product.Name;
                    pt.categoryId = product.categoryId;
                    pt.price = product.price;


                    _dataBase.Add(pt);
                    _dataBase.SaveChanges();
                    return "product is added";
                }
                else
                {
                    return "pass correct categoryID";
                }
                

            }
            catch (Exception ex) { 
            throw ex;}
        }

        public List<Category> getAllCategory()
        {
            return _dataBase.Categories.ToList();
        }

        
        public List<ProductCategoryGroups> getListInGroup()
        {
           

            var query = (from c in _dataBase.Categories
                         join p in _dataBase.Products on c.Id equals p.categoryId
                         into prdGroup
                         select new
                         { 
                           c, prdGroup
                         }
                         ).ToList();
            List<ProductCategoryGroups> list = new List<ProductCategoryGroups>();
       
            foreach ( var ct in query )
            {
                ProductCategoryGroups grp = new ProductCategoryGroups();
                grp.CategoryName=ct.c.Name;
                foreach(var p in ct.prdGroup)
                {
                    grp.ProductName = p.Name;
                    grp.price = p.price;
                }
                list.Add( grp );
            }

            if (list.Count > 0)
                return list;
            else
            return null;
        }

        [Authorize]
        public Product getHighestPriceProdcut()
        {

        
        var res = _dataBase.Products.OrderByDescending(x=> x.price).Select(x => new Product
                                            {
                                                price = x.price,
                                                ProductId = x.ProductId,
                                                Name = x.Name,
                                                categoryId = x.categoryId,
                                            }).Take(1);
            Product pt= new Product();

           
            foreach(var p in res)
            {
                pt.price = p.price;
                pt.Name=p.Name;
                pt.categoryId = p.categoryId;
            }
            return pt;

           
        }

        //top 5 products
        public List<Product> topFiveProducts()
        {
            var ans = (from p in _dataBase.Products
                       orderby p.price descending
                       select p).Take(5).ToList();

            return ans;
        }

        public ProductDto getSecondHighestProduct()
        {
            
            var query= (from p in _dataBase.Products 
                       orderby p.price descending
                       select p).ToList().ElementAt(1);

           
            ProductDto product= new ProductDto();

           
            product.categoryId = query.categoryId;
            product.price = query.price;
            product.Name = query.Name;

            return product;
        }


        public List<Product> getsortByPrice()
        {
            var ms = (from p in _dataBase.Products
                      orderby p.price
                      select p).ToList();
            return ms;
        }
    }
}
