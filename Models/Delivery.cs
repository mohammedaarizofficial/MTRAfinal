using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRADashboard.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        public string? RequestID { get; set; }
        public string? LoadingAddress { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMob { get; set; }
        public string? SiteMapFilePath { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
} 