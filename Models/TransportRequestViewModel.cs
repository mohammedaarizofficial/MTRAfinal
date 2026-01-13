using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MTRADashboard.Models
{
    public class TransportRequestViewModel
    {
        // Employee
        public string? EmpID { get; set; }
        public string? EmpName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        // Request
        public string? RequestID { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? PO_SWO_NO { get; set; }
        public string? RequestType { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? Site { get; set; }
        public string? Division { get; set; }
        public string? ReqDepartment { get; set; }
        public string? ProcessType { get; set; }
        public bool BackLoad { get; set; }
        public string? FromSite { get; set; }
        public DateTime? RequiredDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        // Assets (multiple)
        public List<AssetViewModel> Assets { get; set; } = new();

        // Materials (multiple)
        public List<MaterialViewModel> Materials { get; set; } = new();

        // Agreement
        public string? AgreementNo { get; set; }
        public string? AgreementRemarks { get; set; }

        // Accounting
        public string? GLAccountCode { get; set; }
        public string? WBSCode { get; set; }
        public string? CostCenter { get; set; }
        public string? AccountRemarks { get; set; }

        // Delivery
        public string? LoadingAddress { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactMob { get; set; }
        public IFormFile? SiteMapFile { get; set; }
    }

    public class AssetViewModel
    {
        public string? FunctionalLoc { get; set; }
        public string? EquipmentNo { get; set; }
        public decimal? AssetValue { get; set; }
        public string? AssetDesc { get; set; }
        public string? AssetRemarks { get; set; }
    }

    public class MaterialViewModel
    {
        public string? MaterialDesc { get; set; }
        public decimal? MaterialValue { get; set; }
        public string? MaterialCode { get; set; }
        public string? WPSCode { get; set; }
    }
} 