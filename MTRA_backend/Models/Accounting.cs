using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Accounting
    {
        [Key]
        public int AccountID { get; set; }
        public string RequestID { get; set; } // FK to Request
        public string GLAccountCode { get; set; }
        public string WBSCode { get; set; }
        public string CostCenter { get; set; }
        public string AccountRemarks { get; set; }
    }
}
