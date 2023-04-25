using System.ComponentModel.DataAnnotations;

namespace EshopApplication.Models
{
    public class UpdateOrders
    {
        [Key]
        public int orderId { get; set; }
        public string status { get; set; }
    }
}
