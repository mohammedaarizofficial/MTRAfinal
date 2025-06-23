using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        public string RequestID { get; set; } // FK to Request
        public string LoadingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMob { get; set; }
        public string SiteMapFilePath { get; set; }
    }
}
