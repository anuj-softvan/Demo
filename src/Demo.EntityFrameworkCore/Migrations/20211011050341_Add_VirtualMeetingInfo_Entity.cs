using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Add_VirtualMeetingInfo_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInspectSchVirtualMeetInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectSchID = table.Column<int>(type: "int", nullable: false),
                    VirtualMeetApp = table.Column<byte>(type: "tinyint", nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_AppInspectSchVirtualMeetInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInspectSchMeeting_InsProjHeadID",
                table: "AppInspectSchMeeting",
                column: "InsProjHeadID",
                unique: true,
                filter: "[InsProjHeadID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppInspectSchMeeting_AppInspectProjHead_InsProjHeadID",
                table: "AppInspectSchMeeting",
                column: "InsProjHeadID",
                principalTable: "AppInspectProjHead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInspectSchMeeting_AppInspectProjHead_InsProjHeadID",
                table: "AppInspectSchMeeting");

            migrationBuilder.DropTable(
                name: "AppInspectSchVirtualMeetInfo");

            migrationBuilder.DropIndex(
                name: "IX_AppInspectSchMeeting_InsProjHeadID",
                table: "AppInspectSchMeeting");
        }
    }
}
