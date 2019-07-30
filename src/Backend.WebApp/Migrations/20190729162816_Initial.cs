using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    departmentName = table.Column<string>(maxLength: 25, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    DeleteBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    DeleteBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    groupName = table.Column<string>(maxLength: 25, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    DeleteBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestBusinesstrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    dateBusinessTrip = table.Column<DateTimeOffset>(nullable: false),
                    from = table.Column<string>(maxLength: 64, nullable: false),
                    to = table.Column<string>(maxLength: 64, nullable: false),
                    totalCostNominal = table.Column<int>(nullable: false),
                    totalCostReimburse = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestBusinesstrips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestMedicals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    dateRequestMedical = table.Column<DateTimeOffset>(nullable: false),
                    medicationType = table.Column<string>(maxLength: 64, nullable: false),
                    totalCostNominal = table.Column<int>(nullable: false),
                    totalCostReimburse = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMedicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuickLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    date = table.Column<DateTimeOffset>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    finishTime = table.Column<DateTime>(nullable: false),
                    totalOvertime = table.Column<int>(nullable: false),
                    purpose = table.Column<string>(maxLength: 64, nullable: false),
                    projectName = table.Column<string>(maxLength: 64, nullable: false),
                    requestTo = table.Column<string>(maxLength: 64, nullable: false),
                    departmentId = table.Column<int>(maxLength: 64, nullable: false),
                    groupId = table.Column<int>(nullable: false),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickLeaves_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuickLeaves_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOvertimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    overtimeType = table.Column<int>(maxLength: 64, nullable: false),
                    dateOvertime = table.Column<DateTimeOffset>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    finishTime = table.Column<DateTime>(nullable: false),
                    totalOvertime = table.Column<int>(nullable: false),
                    departmentId = table.Column<int>(nullable: false),
                    groupId = table.Column<int>(nullable: false),
                    projectName = table.Column<string>(maxLength: 64, nullable: false),
                    requestTo = table.Column<string>(maxLength: 25, nullable: false),
                    transportReimbursement = table.Column<int>(nullable: false),
                    mealReimbursement = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOvertimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOvertimes_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestOvertimes_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestBusinesstripApprovalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(nullable: false),
                    ApprovalStatusRequestBusinesstrip = table.Column<int>(nullable: false),
                    RequestBusinesstripId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestBusinesstripApprovalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestBusinesstripApprovalHistory_RequestBusinesstrips_RequestBusinesstripId",
                        column: x => x.RequestBusinesstripId,
                        principalTable: "RequestBusinesstrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestMedicalApprovalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(nullable: false),
                    ApprovalStatusRequestMedical = table.Column<int>(nullable: false),
                    RequestMedicalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMedicalApprovalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestMedicalApprovalHistory_RequestMedicals_RequestMedicalId",
                        column: x => x.RequestMedicalId,
                        principalTable: "RequestMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuickLeaveApprovalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(nullable: false),
                    ApprovalStatusQuickLeave = table.Column<int>(nullable: false),
                    QuickLeaveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickLeaveApprovalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickLeaveApprovalHistory_QuickLeaves_QuickLeaveId",
                        column: x => x.QuickLeaveId,
                        principalTable: "QuickLeaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOvertimeApprovalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 64, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(nullable: false),
                    ApprovalStatusRequestOvertime = table.Column<int>(nullable: false),
                    RequestOvertimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOvertimeApprovalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOvertimeApprovalHistory_RequestOvertimes_RequestOvertimeId",
                        column: x => x.RequestOvertimeId,
                        principalTable: "RequestOvertimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuickLeaveApprovalHistory_QuickLeaveId",
                table: "QuickLeaveApprovalHistory",
                column: "QuickLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickLeaves_departmentId",
                table: "QuickLeaves",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickLeaves_groupId",
                table: "QuickLeaves",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestBusinesstripApprovalHistory_RequestBusinesstripId",
                table: "RequestBusinesstripApprovalHistory",
                column: "RequestBusinesstripId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMedicalApprovalHistory_RequestMedicalId",
                table: "RequestMedicalApprovalHistory",
                column: "RequestMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOvertimeApprovalHistory_RequestOvertimeId",
                table: "RequestOvertimeApprovalHistory",
                column: "RequestOvertimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOvertimes_departmentId",
                table: "RequestOvertimes",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOvertimes_groupId",
                table: "RequestOvertimes",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "QuickLeaveApprovalHistory");

            migrationBuilder.DropTable(
                name: "RequestBusinesstripApprovalHistory");

            migrationBuilder.DropTable(
                name: "RequestMedicalApprovalHistory");

            migrationBuilder.DropTable(
                name: "RequestOvertimeApprovalHistory");

            migrationBuilder.DropTable(
                name: "QuickLeaves");

            migrationBuilder.DropTable(
                name: "RequestBusinesstrips");

            migrationBuilder.DropTable(
                name: "RequestMedicals");

            migrationBuilder.DropTable(
                name: "RequestOvertimes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
