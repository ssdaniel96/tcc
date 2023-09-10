using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Sensors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sensors");

            migrationBuilder.CreateTable(
                name: "Sensor",
                schema: "sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "locations",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sensor_Location_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "locations",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_LocationId",
                schema: "sensors",
                table: "Sensor",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_LocationId1",
                schema: "sensors",
                table: "Sensor",
                column: "LocationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor",
                schema: "sensors");
        }
    }
}
