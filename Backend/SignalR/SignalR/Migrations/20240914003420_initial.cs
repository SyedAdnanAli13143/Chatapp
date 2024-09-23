using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Person__3214EC072C15C01C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignalrId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Connecti__3214EC0773C23469", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Connectio__Perso__398D8EEE",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_PersonId",
                table: "Connections",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
