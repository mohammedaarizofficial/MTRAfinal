using System;
using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Request
    {
        [Key]
        public string RequestID { get; set; }
        public DateTime RequestDate { get; set; }
        public string PO_SWO_NO { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Site { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string ProcessType { get; set; }
        public bool BackLoad { get; set; }
        public string FromSite { get; set; }
        public DateTime RequiredDate { get; set; }
        public string CreatedByEmpID { get; set; } // (could also create a navigation property to Employee)
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
