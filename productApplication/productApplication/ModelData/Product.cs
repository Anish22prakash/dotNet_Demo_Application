using System.ComponentModel.DataAnnotations;

namespace productApplication.ModelData
{
    public class Product

    {
        [Key]
        public int id { get; set; }
        public string productName { get; set; }
        public string category { get; set; }
        public float price { get; set; }
    }
}
