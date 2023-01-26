using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppEFCore.Migrations
{
    /// <inheritdoc />
    public partial class _2401 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyParticipant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoParticipants = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParticipant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EventMemo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrivateParticipant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalIdNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateParticipant", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyParticipant");

            migrationBuilder.DropTable(
                name: "EventInfo");

            migrationBuilder.DropTable(
                name: "PrivateParticipant");
        }
    }
}
