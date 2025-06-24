using Microsoft.AspNetCore.Mvc.RazorPages;
using MTRADashboard.Models;

namespace MTRADashboard.Pages
{
    public class IndexModel : PageModel
    {
        public DashboardStats Stats { get; set; } = new();
        public List<WeeklyData> WeeklyStats { get; set; } = new();
        public List<TransportRequest> RecentRequests { get; set; } = new();

        public void OnGet()
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Sample data - in real application, this would come from database
            Stats = new DashboardStats
            {
                PendingRequests = 12,
                ApprovedRequests = 8,
                RejectedRequests = 3,
                ActiveTransports = 5
            };

            // Updated to use full day names for better chart display
            WeeklyStats = new List<WeeklyData>
            {
                new() { Day = "Sun", Requests = 5 },
                new() { Day = "Mon", Requests = 6 },
                new() { Day = "Tue", Requests = 5 },
                new() { Day = "Wed", Requests = 6 },
                new() { Day = "Thu", Requests = 7 },
                new() { Day = "Fri", Requests = 8 },
                new() { Day = "Sat", Requests = 9 }
            };

            RecentRequests = new List<TransportRequest>
            {
                new()
                {
                    RequestId = "MTRA0123",
                    Type = "Land",
                    Destination = "Abu Dhabi",
                    Status = RequestStatus.Pending,
                    CreatedDate = DateTime.Now.AddDays(-1)
                },
                new()
                {
                    RequestId = "MTRA0118",
                    Type = "Overseas",
                    Destination = "Abu Dhabi Rotterdam",
                    Status = RequestStatus.Approved,
                    CreatedDate = DateTime.Now.AddDays(-2)
                }
            };
        }
    }
}