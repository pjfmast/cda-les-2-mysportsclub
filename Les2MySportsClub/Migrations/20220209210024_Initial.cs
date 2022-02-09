using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Les2MySportsClub.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StartMembership = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapacityLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    WorkoutID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Workout_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "Workout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "ID", "Name", "StartMembership" },
                values: new object[,]
                {
                    { 1, "Esther", new DateTime(2014, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Anton", new DateTime(2018, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Manon", new DateTime(2016, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Joke", new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Jeroen", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Ellen", new DateTime(2010, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Eva", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Anke", new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Koen", new DateTime(2015, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "ID", "CapacityLeft", "EndTime", "Instructor", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, 35, new DateTime(2022, 2, 14, 11, 0, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2022, 2, 14, 10, 15, 0, 0, DateTimeKind.Local), "Yin Yoga" },
                    { 2, 30, new DateTime(2022, 2, 14, 18, 0, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2022, 2, 14, 17, 0, 0, 0, DateTimeKind.Local), "Pilates" },
                    { 3, 35, new DateTime(2022, 2, 15, 11, 15, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2022, 2, 15, 10, 15, 0, 0, DateTimeKind.Local), "Hot Yoga" },
                    { 4, 30, new DateTime(2022, 2, 15, 20, 15, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2022, 2, 15, 19, 15, 0, 0, DateTimeKind.Local), "Club Power" },
                    { 5, 25, new DateTime(2022, 2, 9, 10, 15, 0, 0, DateTimeKind.Local), null, "Room 2", new DateTime(2022, 2, 9, 9, 15, 0, 0, DateTimeKind.Local), "XCO" },
                    { 6, 16, new DateTime(2022, 2, 9, 11, 15, 0, 0, DateTimeKind.Local), null, "Boxing Area", new DateTime(2022, 2, 9, 10, 15, 0, 0, DateTimeKind.Local), "B&K Training" },
                    { 7, 35, new DateTime(2022, 2, 9, 20, 0, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2022, 2, 9, 19, 15, 0, 0, DateTimeKind.Local), "Callanetics" },
                    { 8, 18, new DateTime(2022, 2, 10, 11, 15, 0, 0, DateTimeKind.Local), null, "Room 4", new DateTime(2022, 2, 10, 10, 15, 0, 0, DateTimeKind.Local), "Spinning" },
                    { 9, 30, new DateTime(2022, 2, 10, 18, 15, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2022, 2, 10, 17, 15, 0, 0, DateTimeKind.Local), "Vinyasa Yoga" },
                    { 10, 35, new DateTime(2022, 2, 11, 11, 0, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2022, 2, 11, 10, 15, 0, 0, DateTimeKind.Local), "TBW" },
                    { 11, 12, new DateTime(2022, 2, 11, 11, 15, 0, 0, DateTimeKind.Local), null, "Room 2", new DateTime(2022, 2, 11, 10, 30, 0, 0, DateTimeKind.Local), "Shred and Burn" },
                    { 12, 8, new DateTime(2022, 2, 11, 19, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2022, 2, 11, 18, 15, 0, 0, DateTimeKind.Local), "Cycle Interval" },
                    { 13, 12, new DateTime(2022, 2, 12, 10, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2022, 2, 12, 9, 15, 0, 0, DateTimeKind.Local), "Spinning" },
                    { 14, 6, new DateTime(2022, 2, 13, 11, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2022, 2, 13, 10, 15, 0, 0, DateTimeKind.Local), "Cycle & Abs" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "ID", "MemberID", "WorkoutID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 3, 2, 2 },
                    { 4, 2, 5 },
                    { 5, 2, 14 },
                    { 6, 3, 4 },
                    { 7, 3, 8 },
                    { 8, 4, 1 },
                    { 9, 4, 4 },
                    { 10, 4, 10 },
                    { 11, 4, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MemberID",
                table: "Enrollment",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_WorkoutID",
                table: "Enrollment",
                column: "WorkoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
