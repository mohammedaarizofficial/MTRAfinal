using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public string RequestID { get; set; } // FK to Request
        public string MaterialDesc { get; set; }
        public decimal MaterialValue { get; set; }
        public string MaterialCode { get; set; }
        public string WPSCode { get; set; }
    }
}
