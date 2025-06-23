using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Agreement
    {
        [Key]
        public int AgreementID { get; set; }
        public string RequestID { get; set; } // FK to Request
        public string AgreementNo { get; set; }
        public string AgreementRemarks { get; set; }
    }
}
