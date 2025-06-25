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
                },
                new()
                {
                    RequestId = "MTRA0117",
                    Type = "Land",
                    Destination = "Dubai",
                    Status = RequestStatus.Active,
                    CreatedDate = DateTime.Now.AddDays(-2)
                },
                new()
                {
                    RequestId = "MTRA0116",
                    Type = "Land",
                    Destination = "Sharjah",
                    Status = RequestStatus.Rejected,
                    CreatedDate = DateTime.Now.AddDays(-3)
                },
                new()
                {
                    RequestId = "MTRA0115",
                    Type = "Overseas",
                    Destination = "Abu Dhabi Singapore",
                    Status = RequestStatus.Pending,
                    CreatedDate = DateTime.Now.AddDays(-3)
                },
                new()
                {
                    RequestId = "MTRA0114",
                    Type = "Land",
                    Destination = "Ras Al Khaimah",
                    Status = RequestStatus.Approved,
                    CreatedDate = DateTime.Now.AddDays(-4)
                },
                new()
                {
                    RequestId = "MTRA0113",
                    Type = "Overseas",
                    Destination = "Abu Dhabi Shanghai",
                    Status = RequestStatus.Active,
                    CreatedDate = DateTime.Now.AddDays(-4)
                },
                new()
                {
                    RequestId = "MTRA0112",
                    Type = "Land",
                    Destination = "Al Ain",
                    Status = RequestStatus.Pending,
                    CreatedDate = DateTime.Now.AddDays(-5)
                }
            };
        }
    }
}