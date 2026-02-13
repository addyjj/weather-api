using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceData",
                columns: table => new
                {
                    DateUtc = table.Column<long>(type: "bigint", nullable: false),
                    TempIn = table.Column<double>(type: "float", nullable: false),
                    HumidityIn = table.Column<int>(type: "int", nullable: false),
                    BaromRel = table.Column<double>(type: "float", nullable: false),
                    BaromAbs = table.Column<double>(type: "float", nullable: false),
                    TempOut = table.Column<double>(type: "float", nullable: false),
                    BattOut = table.Column<bool>(type: "bit", nullable: false),
                    HumidityOut = table.Column<int>(type: "int", nullable: false),
                    WindDir = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<double>(type: "float", nullable: false),
                    WindGust = table.Column<double>(type: "float", nullable: false),
                    MaxDailyGust = table.Column<double>(type: "float", nullable: false),
                    HourlyRainRate = table.Column<double>(type: "float", nullable: false),
                    EventRain = table.Column<double>(type: "float", nullable: false),
                    DailyRain = table.Column<double>(type: "float", nullable: false),
                    WeeklyRain = table.Column<double>(type: "float", nullable: false),
                    MonthlyRain = table.Column<double>(type: "float", nullable: false),
                    TotalRain = table.Column<double>(type: "float", nullable: false),
                    SolarRadiation = table.Column<double>(type: "float", nullable: false),
                    Uv = table.Column<int>(type: "int", nullable: false),
                    BattCo2 = table.Column<bool>(type: "bit", nullable: false),
                    FeelsLike = table.Column<double>(type: "float", nullable: false),
                    DewPoint = table.Column<double>(type: "float", nullable: false),
                    FeelsLikeIn = table.Column<double>(type: "float", nullable: false),
                    DewPointIn = table.Column<double>(type: "float", nullable: false),
                    Loc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceData", x => x.DateUtc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceData");
        }
    }
}
