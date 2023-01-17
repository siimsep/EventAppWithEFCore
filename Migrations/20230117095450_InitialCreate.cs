using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAppEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompany",
                table: "PrivateParticipant");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "PrivateParticipant",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                    EventInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParticipant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyParticipant_EventInfo_EventInfoID",
                        column: x => x.EventInfoID,
                        principalTable: "EventInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParticipant_EventInfoID",
                table: "CompanyParticipant",
                column: "EventInfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyParticipant");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "PrivateParticipant",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<byte>(
                name: "IsCompany",
                table: "PrivateParticipant",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
