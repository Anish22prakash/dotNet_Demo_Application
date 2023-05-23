using System.ComponentModel.DataAnnotations;

namespace LinQ_practice_18_05.Model
{
    public class Product
    {
        [Key]
        public int  ProductId { get; set; }
        public string Name { get; set; }
        public int price { get; set; }

        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}
