using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTRADashboard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsignmentNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCollectionPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitiatorContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FunctionalLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssetRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssetValueUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WbsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadingPointAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPointMapPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportRequests");
        }
    }
}
