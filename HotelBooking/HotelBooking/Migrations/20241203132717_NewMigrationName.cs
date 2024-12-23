using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Amenities",
            //    columns: table => new
            //    {
            //        AmenityId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Amenities", x => x.AmenityId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "TEXT", nullable: false),
            //        Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "TEXT", nullable: false),
            //        UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
            //        EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
            //        PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
            //        SecurityStamp = table.Column<string>(type: "TEXT", nullable: false),
            //        ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false),
            //        PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
            //        LockoutEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Hotels",
            //    columns: table => new
            //    {
            //        HotelId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: false),
            //        Address = table.Column<string>(type: "TEXT", nullable: false),
            //        StarRating = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Hotels", x => x.HotelId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaim",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaim", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaim_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: true),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: true),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
            //        ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
            //        Name = table.Column<string>(type: "TEXT", nullable: false),
            //        Value = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimType = table.Column<string>(type: "TEXT", nullable: false),
            //        ClaimValue = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
            //        ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: false),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_UserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        RoleId = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_UserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
            //        Name = table.Column<string>(type: "TEXT", nullable: false),
            //        Value = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_UserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rooms",
            //    columns: table => new
            //    {
            //        RoomId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        HotelId = table.Column<int>(type: "INTEGER", nullable: false),
            //        RoomType = table.Column<string>(type: "TEXT", nullable: false),
            //        Capacity = table.Column<int>(type: "INTEGER", nullable: false),
            //        PricePerNight = table.Column<decimal>(type: "TEXT", nullable: false),
            //        ImageFileName = table.Column<string>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rooms", x => x.RoomId);
            //        table.ForeignKey(
            //            name: "FK_Rooms_Hotels_HotelId",
            //            column: x => x.HotelId,
            //            principalTable: "Hotels",
            //            principalColumn: "HotelId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AmenityRooms",
            //    columns: table => new
            //    {
            //        RoomId = table.Column<int>(type: "INTEGER", nullable: false),
            //        AmenityId = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AmenityRooms", x => new { x.RoomId, x.AmenityId });
            //        table.ForeignKey(
            //            name: "FK_AmenityRooms_Amenities_AmenityId",
            //            column: x => x.AmenityId,
            //            principalTable: "Amenities",
            //            principalColumn: "AmenityId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AmenityRooms_Rooms_RoomId",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "RoomId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Bookings",
            //    columns: table => new
            //    {
            //        BookingId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        UserId = table.Column<string>(type: "TEXT", nullable: false),
            //        RoomId = table.Column<int>(type: "INTEGER", nullable: false),
            //        CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bookings", x => x.BookingId);
            //        table.ForeignKey(
            //            name: "FK_Bookings_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Bookings_Rooms_RoomId",
            //            column: x => x.RoomId,
            //            principalTable: "Rooms",
            //            principalColumn: "RoomId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AmenityRooms_AmenityId",
            //    table: "AmenityRooms",
            //    column: "AmenityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaim_RoleId",
            //    table: "AspNetRoleClaim",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookings_RoomId",
            //    table: "Bookings",
            //    column: "RoomId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bookings_UserId",
            //    table: "Bookings",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rooms_HotelId",
            //    table: "Rooms",
            //    column: "HotelId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserClaims_UserId",
            //    table: "UserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserLogins_UserId",
            //    table: "UserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoles_RoleId",
            //    table: "UserRoles",
            //    column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityRooms");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
