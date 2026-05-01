using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qadia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesIndb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NationalId = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lawsuits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CaseNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CourtName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Circuit = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawsuits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lawsuits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Requirements = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    DecisionType = table.Column<int>(type: "INTEGER", nullable: true),
                    Decision = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    IsActioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LawsuitId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Lawsuits_LawsuitId",
                        column: x => x.LawsuitId,
                        principalTable: "Lawsuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lawsuits_ClientId",
                table: "Lawsuits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_LawsuitId",
                table: "Sessions",
                column: "LawsuitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Lawsuits");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
