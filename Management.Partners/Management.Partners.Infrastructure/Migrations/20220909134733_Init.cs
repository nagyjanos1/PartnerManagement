using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Partners.Infrastructure.Migrations;

public partial class Init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Partner",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Partner", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Address",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AddressValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Address", x => x.Id);
                table.ForeignKey(
                    name: "FK_Address_Partner_PartnerId",
                    column: x => x.PartnerId,
                    principalTable: "Partner",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Address_PartnerId",
            table: "Address",
            column: "PartnerId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Address");

        migrationBuilder.DropTable(
            name: "Partner");
    }
}
