using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessERP.Migrations
{
    /// <inheritdoc />
    public partial class addtenantids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "WarehouseNotification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Warehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "VatPercentage",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "UserInfoFromBrowser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "UnitsofMeasure",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "SubDepartment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "SendEmailHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ReturnLog",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "RefreshToken",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PurchasesPaymentDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PurchasesPayment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PaymentType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PaymentStatus",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PaymentModeHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "PaymentDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Payment",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ManageUserRolesDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ManageUserRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "LoginHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ItemTransferLog",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ItemsHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ItemSerialNumber",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ItemRequest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "IncomeType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "IncomeSummary",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "IncomeCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ExpenseType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ExpenseSummary",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "ExpenseDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "EmailConfig",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Designation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Department",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "DefaultIdentityOptions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "DamageItemDeatils",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "CustomerType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "CustomerInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Currency",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "CompanyInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Branch",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AuditLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "Attendance",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AccTransfer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AccTransaction",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AccExpense",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AccDeposit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenantId",
                table: "AccAccount",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseNotification_TenantId",
                table: "WarehouseNotification",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_TenantId",
                table: "Warehouse",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_VatPercentage_TenantId",
                table: "VatPercentage",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfoFromBrowser_TenantId",
                table: "UserInfoFromBrowser",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsofMeasure_TenantId",
                table: "UnitsofMeasure",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_TenantId",
                table: "Supplier",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartment_TenantId",
                table: "SubDepartment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SendEmailHistory_TenantId",
                table: "SendEmailHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnLog_TenantId",
                table: "ReturnLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_TenantId",
                table: "RefreshToken",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPaymentDetail_TenantId",
                table: "PurchasesPaymentDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesPayment_TenantId",
                table: "PurchasesPayment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_TenantId",
                table: "PaymentType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_TenantId",
                table: "PaymentStatus",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentModeHistory_TenantId",
                table: "PaymentModeHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_TenantId",
                table: "PaymentDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TenantId",
                table: "Payment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageUserRolesDetails_TenantId",
                table: "ManageUserRolesDetails",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageUserRoles_TenantId",
                table: "ManageUserRoles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistory_TenantId",
                table: "LoginHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTransferLog_TenantId",
                table: "ItemTransferLog",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsHistory_TenantId",
                table: "ItemsHistory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSerialNumber_TenantId",
                table: "ItemSerialNumber",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TenantId",
                table: "Items",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequest_TenantId",
                table: "ItemRequest",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeType_TenantId",
                table: "IncomeType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeSummary_TenantId",
                table: "IncomeSummary",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategory_TenantId",
                table: "IncomeCategory",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseType_TenantId",
                table: "ExpenseType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseSummary_TenantId",
                table: "ExpenseSummary",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_TenantId",
                table: "ExpenseDetails",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TenantId",
                table: "Employee",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailConfig_TenantId",
                table: "EmailConfig",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_TenantId",
                table: "Designation",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_TenantId",
                table: "Department",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultIdentityOptions_TenantId",
                table: "DefaultIdentityOptions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DamageItemDeatils_TenantId",
                table: "DamageItemDeatils",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_TenantId",
                table: "CustomerType",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_TenantId",
                table: "CustomerInfo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_TenantId",
                table: "Currency",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfo_TenantId",
                table: "CompanyInfo",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TenantId",
                table: "Categories",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_TenantId",
                table: "Branch",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_TenantId",
                table: "AuditLogs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TenantId",
                table: "Attendance",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccTransfer_TenantId",
                table: "AccTransfer",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccTransaction_TenantId",
                table: "AccTransaction",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccExpense_TenantId",
                table: "AccExpense",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccDeposit_TenantId",
                table: "AccDeposit",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccAccount_TenantId",
                table: "AccAccount",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccAccount_Tenant_TenantId",
                table: "AccAccount",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccDeposit_Tenant_TenantId",
                table: "AccDeposit",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccExpense_Tenant_TenantId",
                table: "AccExpense",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransaction_Tenant_TenantId",
                table: "AccTransaction",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransfer_Tenant_TenantId",
                table: "AccTransfer",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Tenant_TenantId",
                table: "Attendance",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_Tenant_TenantId",
                table: "AuditLogs",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Tenant_TenantId",
                table: "Branch",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Tenant_TenantId",
                table: "Categories",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfo_Tenant_TenantId",
                table: "CompanyInfo",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currency_Tenant_TenantId",
                table: "Currency",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInfo_Tenant_TenantId",
                table: "CustomerInfo",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerType_Tenant_TenantId",
                table: "CustomerType",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageItemDeatils_Tenant_TenantId",
                table: "DamageItemDeatils",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultIdentityOptions_Tenant_TenantId",
                table: "DefaultIdentityOptions",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Tenant_TenantId",
                table: "Department",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_Tenant_TenantId",
                table: "Designation",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailConfig_Tenant_TenantId",
                table: "EmailConfig",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Tenant_TenantId",
                table: "Employee",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_Tenant_TenantId",
                table: "ExpenseDetails",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseSummary_Tenant_TenantId",
                table: "ExpenseSummary",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseType_Tenant_TenantId",
                table: "ExpenseType",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeCategory_Tenant_TenantId",
                table: "IncomeCategory",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeSummary_Tenant_TenantId",
                table: "IncomeSummary",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeType_Tenant_TenantId",
                table: "IncomeType",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequest_Tenant_TenantId",
                table: "ItemRequest",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tenant_TenantId",
                table: "Items",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSerialNumber_Tenant_TenantId",
                table: "ItemSerialNumber",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsHistory_Tenant_TenantId",
                table: "ItemsHistory",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTransferLog_Tenant_TenantId",
                table: "ItemTransferLog",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginHistory_Tenant_TenantId",
                table: "LoginHistory",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageUserRoles_Tenant_TenantId",
                table: "ManageUserRoles",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageUserRolesDetails_Tenant_TenantId",
                table: "ManageUserRolesDetails",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Tenant_TenantId",
                table: "Payment",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_Tenant_TenantId",
                table: "PaymentDetail",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentModeHistory_Tenant_TenantId",
                table: "PaymentModeHistory",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatus_Tenant_TenantId",
                table: "PaymentStatus",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Tenant_TenantId",
                table: "PaymentType",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPayment_Tenant_TenantId",
                table: "PurchasesPayment",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasesPaymentDetail_Tenant_TenantId",
                table: "PurchasesPaymentDetail",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Tenant_TenantId",
                table: "RefreshToken",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnLog_Tenant_TenantId",
                table: "ReturnLog",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SendEmailHistory_Tenant_TenantId",
                table: "SendEmailHistory",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartment_Tenant_TenantId",
                table: "SubDepartment",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Tenant_TenantId",
                table: "Supplier",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsofMeasure_Tenant_TenantId",
                table: "UnitsofMeasure",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoFromBrowser_Tenant_TenantId",
                table: "UserInfoFromBrowser",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_VatPercentage_Tenant_TenantId",
                table: "VatPercentage",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Tenant_TenantId",
                table: "Warehouse",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseNotification_Tenant_TenantId",
                table: "WarehouseNotification",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccAccount_Tenant_TenantId",
                table: "AccAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_AccDeposit_Tenant_TenantId",
                table: "AccDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_AccExpense_Tenant_TenantId",
                table: "AccExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_AccTransaction_Tenant_TenantId",
                table: "AccTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_AccTransfer_Tenant_TenantId",
                table: "AccTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Tenant_TenantId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_Tenant_TenantId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Tenant_TenantId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Tenant_TenantId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfo_Tenant_TenantId",
                table: "CompanyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Currency_Tenant_TenantId",
                table: "Currency");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInfo_Tenant_TenantId",
                table: "CustomerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerType_Tenant_TenantId",
                table: "CustomerType");

            migrationBuilder.DropForeignKey(
                name: "FK_DamageItemDeatils_Tenant_TenantId",
                table: "DamageItemDeatils");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultIdentityOptions_Tenant_TenantId",
                table: "DefaultIdentityOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Tenant_TenantId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Designation_Tenant_TenantId",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailConfig_Tenant_TenantId",
                table: "EmailConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Tenant_TenantId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_Tenant_TenantId",
                table: "ExpenseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseSummary_Tenant_TenantId",
                table: "ExpenseSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseType_Tenant_TenantId",
                table: "ExpenseType");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeCategory_Tenant_TenantId",
                table: "IncomeCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeSummary_Tenant_TenantId",
                table: "IncomeSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeType_Tenant_TenantId",
                table: "IncomeType");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequest_Tenant_TenantId",
                table: "ItemRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tenant_TenantId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemSerialNumber_Tenant_TenantId",
                table: "ItemSerialNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsHistory_Tenant_TenantId",
                table: "ItemsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTransferLog_Tenant_TenantId",
                table: "ItemTransferLog");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginHistory_Tenant_TenantId",
                table: "LoginHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageUserRoles_Tenant_TenantId",
                table: "ManageUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageUserRolesDetails_Tenant_TenantId",
                table: "ManageUserRolesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Tenant_TenantId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_Tenant_TenantId",
                table: "PaymentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentModeHistory_Tenant_TenantId",
                table: "PaymentModeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatus_Tenant_TenantId",
                table: "PaymentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Tenant_TenantId",
                table: "PaymentType");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPayment_Tenant_TenantId",
                table: "PurchasesPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasesPaymentDetail_Tenant_TenantId",
                table: "PurchasesPaymentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Tenant_TenantId",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnLog_Tenant_TenantId",
                table: "ReturnLog");

            migrationBuilder.DropForeignKey(
                name: "FK_SendEmailHistory_Tenant_TenantId",
                table: "SendEmailHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartment_Tenant_TenantId",
                table: "SubDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Tenant_TenantId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsofMeasure_Tenant_TenantId",
                table: "UnitsofMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoFromBrowser_Tenant_TenantId",
                table: "UserInfoFromBrowser");

            migrationBuilder.DropForeignKey(
                name: "FK_VatPercentage_Tenant_TenantId",
                table: "VatPercentage");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Tenant_TenantId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseNotification_Tenant_TenantId",
                table: "WarehouseNotification");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseNotification_TenantId",
                table: "WarehouseNotification");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_TenantId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_VatPercentage_TenantId",
                table: "VatPercentage");

            migrationBuilder.DropIndex(
                name: "IX_UserInfoFromBrowser_TenantId",
                table: "UserInfoFromBrowser");

            migrationBuilder.DropIndex(
                name: "IX_UnitsofMeasure_TenantId",
                table: "UnitsofMeasure");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_TenantId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartment_TenantId",
                table: "SubDepartment");

            migrationBuilder.DropIndex(
                name: "IX_SendEmailHistory_TenantId",
                table: "SendEmailHistory");

            migrationBuilder.DropIndex(
                name: "IX_ReturnLog_TenantId",
                table: "ReturnLog");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_TenantId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesPaymentDetail_TenantId",
                table: "PurchasesPaymentDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchasesPayment_TenantId",
                table: "PurchasesPayment");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_TenantId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatus_TenantId",
                table: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_PaymentModeHistory_TenantId",
                table: "PaymentModeHistory");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetail_TenantId",
                table: "PaymentDetail");

            migrationBuilder.DropIndex(
                name: "IX_Payment_TenantId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_ManageUserRolesDetails_TenantId",
                table: "ManageUserRolesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ManageUserRoles_TenantId",
                table: "ManageUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_LoginHistory_TenantId",
                table: "LoginHistory");

            migrationBuilder.DropIndex(
                name: "IX_ItemTransferLog_TenantId",
                table: "ItemTransferLog");

            migrationBuilder.DropIndex(
                name: "IX_ItemsHistory_TenantId",
                table: "ItemsHistory");

            migrationBuilder.DropIndex(
                name: "IX_ItemSerialNumber_TenantId",
                table: "ItemSerialNumber");

            migrationBuilder.DropIndex(
                name: "IX_Items_TenantId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequest_TenantId",
                table: "ItemRequest");

            migrationBuilder.DropIndex(
                name: "IX_IncomeType_TenantId",
                table: "IncomeType");

            migrationBuilder.DropIndex(
                name: "IX_IncomeSummary_TenantId",
                table: "IncomeSummary");

            migrationBuilder.DropIndex(
                name: "IX_IncomeCategory_TenantId",
                table: "IncomeCategory");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseType_TenantId",
                table: "ExpenseType");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseSummary_TenantId",
                table: "ExpenseSummary");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDetails_TenantId",
                table: "ExpenseDetails");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TenantId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_EmailConfig_TenantId",
                table: "EmailConfig");

            migrationBuilder.DropIndex(
                name: "IX_Designation_TenantId",
                table: "Designation");

            migrationBuilder.DropIndex(
                name: "IX_Department_TenantId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_DefaultIdentityOptions_TenantId",
                table: "DefaultIdentityOptions");

            migrationBuilder.DropIndex(
                name: "IX_DamageItemDeatils_TenantId",
                table: "DamageItemDeatils");

            migrationBuilder.DropIndex(
                name: "IX_CustomerType_TenantId",
                table: "CustomerType");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInfo_TenantId",
                table: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_Currency_TenantId",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_CompanyInfo_TenantId",
                table: "CompanyInfo");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TenantId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Branch_TenantId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_AuditLogs_TenantId",
                table: "AuditLogs");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_TenantId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_AccTransfer_TenantId",
                table: "AccTransfer");

            migrationBuilder.DropIndex(
                name: "IX_AccTransaction_TenantId",
                table: "AccTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccExpense_TenantId",
                table: "AccExpense");

            migrationBuilder.DropIndex(
                name: "IX_AccDeposit_TenantId",
                table: "AccDeposit");

            migrationBuilder.DropIndex(
                name: "IX_AccAccount_TenantId",
                table: "AccAccount");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "WarehouseNotification");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "VatPercentage");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "UserInfoFromBrowser");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "UnitsofMeasure");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SubDepartment");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SendEmailHistory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ReturnLog");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PurchasesPaymentDetail");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PurchasesPayment");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PaymentStatus");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PaymentModeHistory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ManageUserRolesDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ManageUserRoles");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "LoginHistory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ItemTransferLog");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ItemsHistory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ItemSerialNumber");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ItemRequest");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "IncomeType");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "IncomeSummary");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "IncomeCategory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExpenseType");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExpenseSummary");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "EmailConfig");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DefaultIdentityOptions");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DamageItemDeatils");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CompanyInfo");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AccTransfer");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AccTransaction");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AccExpense");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AccDeposit");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AccAccount");
        }
    }
}
