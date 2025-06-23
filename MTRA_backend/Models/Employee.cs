using System.ComponentModel.DataAnnotations;

namespace MTRA_Backend.Models
{
    public class Employee
    {
        [Key]
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
