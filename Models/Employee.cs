using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MTRADashboard.Models
{
    public class Employee
    {
        [Key]
        public string EmpID { get; set; } = string.Empty;
        public string? EmpName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        public ICollection<Request>? Requests { get; set; }
    }
} 