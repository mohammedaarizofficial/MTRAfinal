using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRADashboard.Models
{
    public class Asset
    {
        [Key]
        public int AssetID { get; set; }
        public string? RequestID { get; set; }
        public string? FunctionalLoc { get; set; }
        public string? EquipmentNo { get; set; }
        public decimal? AssetValue { get; set; }
        public string? AssetDesc { get; set; }
        public string? AssetRemarks { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
} 