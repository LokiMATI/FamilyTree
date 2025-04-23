using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTree.Services.Migrations
{
    /// <inheritdoc />
    public partial class Added_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    Patronymic = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Birthplace = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeathDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeathPlace = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FatherId = table.Column<Guid>(type: "uuid", nullable: true),
                    MotherId = table.Column<Guid>(type: "uuid", nullable: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Biography = table.Column<string>(type: "character varying(500000)", maxLength: 500000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Person_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Person_Person_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_FatherId",
                table: "Person",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FirstName_LastName",
                table: "Person",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_MotherId",
                table: "Person",
                column: "MotherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
