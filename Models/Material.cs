using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRADashboard.Models
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public string? RequestID { get; set; }
        public string? MaterialDesc { get; set; }
        public decimal? MaterialValue { get; set; }
        public string? MaterialCode { get; set; }
        public string? WPSCode { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
} 