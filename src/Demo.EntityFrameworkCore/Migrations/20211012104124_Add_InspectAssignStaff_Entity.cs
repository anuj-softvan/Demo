using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Add_InspectAssignStaff_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInspectSchAssignStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAccepted = table.Column<byte>(type: "tinyint", nullable: false),
                    AcceptedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptRemarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InspectSchID = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInspectSchAssignStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInspectSchAssignStaff_AppInspectSchMeeting_InspectSchID",
                        column: x => x.InspectSchID,
                        principalTable: "AppInspectSchMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInspectSchAssignStaff_InspectSchID",
                table: "AppInspectSchAssignStaff",
                column: "InspectSchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInspectSchAssignStaff");
        }
    }
}
