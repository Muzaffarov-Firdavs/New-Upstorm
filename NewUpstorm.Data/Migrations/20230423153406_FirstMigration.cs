using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewUpstorm.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NowTemperature = table.Column<float>(type: "real", nullable: false),
                    NightTemperature = table.Column<float>(type: "real", nullable: false),
                    DayTemperature = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SunTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sunrise = table.Column<int>(type: "int", nullable: false),
                    Sunset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootObjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainInfoId = table.Column<long>(type: "bigint", nullable: false),
                    SunTimeId = table.Column<long>(type: "bigint", nullable: false),
                    WindInfoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootObjects_MainInfos_MainInfoId",
                        column: x => x.MainInfoId,
                        principalTable: "MainInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_SunTimes_SunTimeId",
                        column: x => x.SunTimeId,
                        principalTable: "SunTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootObjects_WindInfos_WindInfoId",
                        column: x => x.WindInfoId,
                        principalTable: "WindInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootObjectId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherInfos_RootObjects_RootObjectId",
                        column: x => x.RootObjectId,
                        principalTable: "RootObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_MainInfoId",
                table: "RootObjects",
                column: "MainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_SunTimeId",
                table: "RootObjects",
                column: "SunTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObjects_WindInfoId",
                table: "RootObjects",
                column: "WindInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherInfos_RootObjectId",
                table: "WeatherInfos",
                column: "RootObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeatherInfos");

            migrationBuilder.DropTable(
                name: "RootObjects");

            migrationBuilder.DropTable(
                name: "MainInfos");

            migrationBuilder.DropTable(
                name: "SunTimes");

            migrationBuilder.DropTable(
                name: "WindInfos");
        }
    }
}
