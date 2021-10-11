using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Change_InspectSchMeeting_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingMode",
                table: "AppInspectSchMeeting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MeetingMode",
                table: "AppInspectSchMeeting",
                type: "tinyint",
                maxLength: 4,
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
