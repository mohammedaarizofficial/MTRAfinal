using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Asset
    {
        [Key]
        public int AssetID { get; set; }
        public string RequestID { get; set; } // FK to Request
        public string FunctionalLoc { get; set; }
        public string EquipmentNo { get; set; }
        public decimal AssetValue { get; set; }
        public string AssetDesc { get; set; }
        public string AssetRemarks { get; set; }
    }
}
