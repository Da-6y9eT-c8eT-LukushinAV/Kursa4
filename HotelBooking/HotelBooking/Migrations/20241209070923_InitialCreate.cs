using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "HasAirConditioner",
            //    table: "Rooms",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "HasHairDryer",
            //    table: "Rooms",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "HasSafe",
            //    table: "Rooms",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "HasTV",
            //    table: "Rooms",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "HasWifi",
            //    table: "Rooms",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "HasAirConditioner",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HasHairDryer",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HasSafe",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HasTV",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HasWifi",
                table: "Rooms");
        }
    }
}
