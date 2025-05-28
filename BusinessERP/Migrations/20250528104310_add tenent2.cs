using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessERP.Migrations
{
    /// <inheritdoc />
    public partial class addtenent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "UserProfile",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenancyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionEndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsInTrialPeriod = table.Column<bool>(type: "bit", nullable: false),
                    CustomCssId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EInvoiceCompanyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EInvoiceRegistrationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatoraClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatoraSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatoraIncomeSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatoraClientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_TenantId",
                table: "UserProfile",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_Tenant_TenantId",
                table: "UserProfile",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_Tenant_TenantId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_UserProfile_TenantId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "UserProfile");
        }
    }
}
