using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Add_FK_InspectSchMeeting_VirtualInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppInspectSchVirtualMeetInfo_InspectSchID",
                table: "AppInspectSchVirtualMeetInfo",
                column: "InspectSchID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppInspectSchVirtualMeetInfo_AppInspectSchMeeting_InspectSchID",
                table: "AppInspectSchVirtualMeetInfo",
                column: "InspectSchID",
                principalTable: "AppInspectSchMeeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppInspectSchVirtualMeetInfo_AppInspectSchMeeting_InspectSchID",
                table: "AppInspectSchVirtualMeetInfo");

            migrationBuilder.DropIndex(
                name: "IX_AppInspectSchVirtualMeetInfo_InspectSchID",
                table: "AppInspectSchVirtualMeetInfo");
        }
    }
}
