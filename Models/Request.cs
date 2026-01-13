using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace MTRADashboard.Models
{
    public class Request
    {
        [Key]
        public string RequestID { get; set; } = string.Empty;
        public DateTime? RequestDate { get; set; }
        public string? PO_SWO_NO { get; set; }
        public string? RequestType { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? Site { get; set; }
        public string? Division { get; set; }
        public string? Department { get; set; }
        public string? ProcessType { get; set; }
        public bool? BackLoad { get; set; }
        public string? FromSite { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string? CreatedByEmpID { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey("CreatedByEmpID")]
        public Employee? CreatedByEmployee { get; set; }

        public ICollection<Asset>? Assets { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public ICollection<Agreement>? Agreements { get; set; }
        public ICollection<Accounting>? Accountings { get; set; }
        public ICollection<Delivery>? Deliveries { get; set; }
    }
} 