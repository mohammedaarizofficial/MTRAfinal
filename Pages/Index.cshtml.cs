using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTRADashboard.Models;

namespace MTRADashboard.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

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

            WeeklyStats = new List<WeeklyData>
            {
                new() { Day = "S", Requests = 5 },
                new() { Day = "M", Requests = 6 },
                new() { Day = "T", Requests = 5 },
                new() { Day = "W", Requests = 6 },
                new() { Day = "T", Requests = 7 },
                new() { Day = "F", Requests = 8 },
                new() { Day = "S", Requests = 9 },
                new() { Day = "S", Requests = 8 }
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