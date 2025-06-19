using System.ComponentModel.DataAnnotations;

namespace MTRADashboard.Models
{
    public class TransportRequest
    {
        public string RequestId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public RequestStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
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