using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Add_Meeting_And_Participents_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AppMeetingInspectors",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "AppCivitMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgID = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingMode = table.Column<byte>(type: "tinyint", maxLength: 4, nullable: false),
                    Meetinginvitation = table.Column<string>(type: "ntext", nullable: true),
                    SlotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlotStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlotEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleStatus = table.Column<byte>(type: "tinyint", maxLength: 3, nullable: false),
                    Compliancestatus = table.Column<byte>(type: "tinyint", maxLength: 2, nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CanceledById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanceledOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelationReason = table.Column<string>(type: "ntext", nullable: true),
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
                    table.PrimaryKey("PK_AppCivitMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMeetingParticipents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MeetingID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppMeetingParticipents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMeetingParticipents_AppCivitMeeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "AppCivitMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMeetingParticipents_MeetingID",
                table: "AppMeetingParticipents",
                column: "MeetingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AppMeetingParticipents");

            //migrationBuilder.DropTable(
            //    name: "AppCivitMeeting");

            //migrationBuilder.AlterColumn<Guid>(
            //    name: "Id",
            //    table: "AppMeetingInspectors",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
