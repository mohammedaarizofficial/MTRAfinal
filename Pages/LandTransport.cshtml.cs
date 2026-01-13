using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTRADashboard.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System;

namespace MTRADashboard.Pages;

public class LandTransportModel : PageModel
{
    private readonly ILogger<LandTransportModel> _logger;
    private readonly MTRADbContext _context;
    private readonly IWebHostEnvironment _environment;

    public LandTransportModel(ILogger<LandTransportModel> logger, MTRADbContext context, IWebHostEnvironment environment)
    {
        _logger = logger;
        _context = context;
        _environment = environment;
    }

    [BindProperty]
    public TransportRequestViewModel TransportRequest { get; set; } = new TransportRequestViewModel();

    public void OnGet()
    {
        // No logic needed for GET
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // 1. Check for existing Employee by email
        var employee = _context.Employees.FirstOrDefault(e => e.Email == TransportRequest.Email);
        string empId;
        if (employee == null)
        {
            empId = Guid.NewGuid().ToString();
            employee = new Employee
            {
                EmpID = empId,
                EmpName = TransportRequest.EmpName,
                Designation = TransportRequest.Designation,
                Department = TransportRequest.Department,
                ContactNumber = TransportRequest.ContactNumber,
                Email = TransportRequest.Email
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        else
        {
            empId = employee.EmpID;
        }

        // 2. Create Request
        string requestId = "REQ-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        var request = new Request
        {
            RequestID = requestId,
            RequestDate = TransportRequest.RequestDate ?? DateTime.Now,
            PO_SWO_NO = TransportRequest.PO_SWO_NO,
            RequestType = TransportRequest.RequestType,
            Status = "Pending",
            Priority = TransportRequest.Priority,
            Site = TransportRequest.Site,
            Division = TransportRequest.Division,
            Department = TransportRequest.ReqDepartment ?? TransportRequest.Department,
            ProcessType = TransportRequest.ProcessType,
            BackLoad = TransportRequest.BackLoad,
            FromSite = TransportRequest.FromSite,
            RequiredDate = TransportRequest.RequiredDate,
            CreatedByEmpID = empId,
            IsActive = true,
            IsDeleted = false
        };
        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        // 3. Insert Assets
        if (TransportRequest.Assets != null)
        {
            foreach (var assetVm in TransportRequest.Assets)
            {
                var asset = new Asset
                {
                    RequestID = requestId,
                    FunctionalLoc = assetVm.FunctionalLoc,
                    EquipmentNo = assetVm.EquipmentNo,
                    AssetValue = assetVm.AssetValue,
                    AssetDesc = assetVm.AssetDesc,
                    AssetRemarks = assetVm.AssetRemarks
                };
                _context.Assets.Add(asset);
            }
        }

        // 4. Insert Materials
        if (TransportRequest.Materials != null)
        {
            foreach (var matVm in TransportRequest.Materials)
            {
                var material = new Material
                {
                    RequestID = requestId,
                    MaterialDesc = matVm.MaterialDesc,
                    MaterialValue = matVm.MaterialValue,
                    MaterialCode = matVm.MaterialCode,
                    WPSCode = matVm.WPSCode
                };
                _context.Materials.Add(material);
            }
        }

        // 5. Insert Agreement
        if (!string.IsNullOrWhiteSpace(TransportRequest.AgreementNo) || !string.IsNullOrWhiteSpace(TransportRequest.AgreementRemarks))
        {
            var agreement = new Agreement
            {
                RequestID = requestId,
                AgreementNo = TransportRequest.AgreementNo,
                AgreementRemarks = TransportRequest.AgreementRemarks
            };
            _context.Agreements.Add(agreement);
        }

        // 6. Insert Accounting
        if (!string.IsNullOrWhiteSpace(TransportRequest.GLAccountCode) || !string.IsNullOrWhiteSpace(TransportRequest.WBSCode) || !string.IsNullOrWhiteSpace(TransportRequest.CostCenter))
        {
            var accounting = new Accounting
            {
                RequestID = requestId,
                GLAccountCode = TransportRequest.GLAccountCode,
                WBSCode = TransportRequest.WBSCode,
                CostCenter = TransportRequest.CostCenter,
                AccountRemarks = TransportRequest.AccountRemarks
            };
            _context.Accountings.Add(accounting);
        }

        // 7. Handle file upload for Delivery
        string? siteMapPath = null;
        if (TransportRequest.SiteMapFile != null && TransportRequest.SiteMapFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);
            var fileName = Path.GetFileNameWithoutExtension(TransportRequest.SiteMapFile.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(TransportRequest.SiteMapFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await TransportRequest.SiteMapFile.CopyToAsync(stream);
            }
            siteMapPath = "/uploads/" + fileName;
        }

        // 8. Insert Delivery
        var delivery = new Delivery
        {
            RequestID = requestId,
            LoadingAddress = TransportRequest.LoadingAddress,
            DeliveryAddress = TransportRequest.DeliveryAddress,
            ContactName = TransportRequest.ContactName,
            ContactEmail = TransportRequest.ContactEmail,
            ContactMob = TransportRequest.ContactMob,
            SiteMapFilePath = siteMapPath
        };
        _context.Deliveries.Add(delivery);

        await _context.SaveChangesAsync();

        // Optionally, redirect to a confirmation page or show a success message
        return RedirectToPage("/Index");
    }
}
