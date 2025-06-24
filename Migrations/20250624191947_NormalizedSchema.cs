using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTRADashboard.Migrations
{
    /// <inheritdoc />
    public partial class NormalizedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportRequests");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PO_SWO_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackLoad = table.Column<bool>(type: "bit", nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmpID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_CreatedByEmpID",
                        column: x => x.CreatedByEmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID");
                });

            migrationBuilder.CreateTable(
                name: "Accountings",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GLAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WBSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountings", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accountings_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AgreementNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgreementRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementID);
                    table.ForeignKey(
                        name: "FK_Agreements_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FunctionalLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssetDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetID);
                    table.ForeignKey(
                        name: "FK_Assets_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoadingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteMapFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryID);
                    table.ForeignKey(
                        name: "FK_Deliveries_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaterialDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WPSCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialID);
                    table.ForeignKey(
                        name: "FK_Materials_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accountings_RequestID",
                table: "Accountings",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RequestID",
                table: "Agreements",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_RequestID",
                table: "Assets",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RequestID",
                table: "Deliveries",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_RequestID",
                table: "Materials",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CreatedByEmpID",
                table: "Requests",
                column: "CreatedByEmpID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accountings");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "TransportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssetValueUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsignmentNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPointMapPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FunctionalLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitiatorContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadingPointAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCollectionPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WbsCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRequests", x => x.Id);
                });
        }
    }
}
