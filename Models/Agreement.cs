using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTRADashboard.Models
{
    public class Agreement
    {
        [Key]
        public int AgreementID { get; set; }
        public string? RequestID { get; set; }
        public string? AgreementNo { get; set; }
        public string? AgreementRemarks { get; set; }

        [ForeignKey("RequestID")]
        public Request? Request { get; set; }
    }
} 