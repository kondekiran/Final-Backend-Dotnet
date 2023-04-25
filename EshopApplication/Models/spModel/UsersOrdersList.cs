using System.ComponentModel.DataAnnotations;

namespace EshopApplication.Models.spModel
{
    public class UsersOrdersList
    {
        [Key]
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
