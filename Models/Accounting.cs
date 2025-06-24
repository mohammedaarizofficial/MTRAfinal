using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRADashboard.Models
{
    public class Accounting
    {
        [Key]
        public int AccountID { get; set; }
        public string? RequestID { get; set; }
        public string? GLAccountCode { get; set; }
        public string? WBSCode { get; set; }
        public string? CostCenter { get; set; }
        public string? AccountRemarks { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
} 