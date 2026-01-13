using System.ComponentModel.DataAnnotations;

namespace MTRADashboard.Models
{
    public class TransportRequest
    {
        [Key]
        public int Id { get; set; }

        // Section 1: General Transport Request Details
        [Required]
        public string From { get; set; } = string.Empty;
        [Required]
        public string FromSite { get; set; } = string.Empty;
        [Required]
        public string Designation { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        public string? ConsignmentNote { get; set; }
        [Required]
        public string MaterialCollectionPoint { get; set; } = string.Empty;
        [Required]
        public string InitiatorContactNumber { get; set; } = string.Empty;
        public string? FunctionalLocation { get; set; }
        public string? EquipmentNumber { get; set; }
        public decimal? AssetValue { get; set; }
        public string? AssetRemarks { get; set; }

        // Section 2: Material Details
        [Required]
        public string MaterialId { get; set; } = string.Empty;
        [Required]
        public string MaterialCode { get; set; } = string.Empty;
        public decimal? MaterialValue { get; set; }
        public decimal? AssetValueUsd { get; set; }
        [Required]
        public string MaterialDescription { get; set; } = string.Empty;
        public string? RoAgreement { get; set; }
        public string? GlAccountCode { get; set; }
        public string? WbsCode { get; set; }
        public string? CostCenter { get; set; }
        [Required]
        public string ContactName { get; set; } = string.Empty;
        [Required]
        public string ContactEmail { get; set; } = string.Empty;
        [Required]
        public string ContactMobile { get; set; } = string.Empty;
        [Required]
        public string LoadingPointAddress { get; set; } = string.Empty;
        [Required]
        public string DeliveryAddress { get; set; } = string.Empty;
        public string? Remarks { get; set; }
        public string? DeliveryPointMapPath { get; set; } // For file upload

        // Existing fields (for dashboard, etc.)
        public string? RequestId { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public string? Destination { get; set; } = string.Empty;
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        Active
    }

    public class DashboardStats
    {
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int RejectedRequests { get; set; }
        public int ActiveTransports { get; set; }
    }

    public class WeeklyData
    {
        public string Day { get; set; } = string.Empty;
        public int Requests { get; set; }
    }
}