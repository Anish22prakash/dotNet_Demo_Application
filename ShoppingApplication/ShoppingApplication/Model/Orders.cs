using Microsoft.VisualBasic;

namespace ShoppingApplication.Model
{
    public class Orders
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int  PaytmentID { get; set; }

        public DateAndTime orderDate { get ; set; }



    }
}
