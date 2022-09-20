using Management.Partners.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Partners.Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DataSeed.Up(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            DataSeed.Down(migrationBuilder);
        }
    }
}
