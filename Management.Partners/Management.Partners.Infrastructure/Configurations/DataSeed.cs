using Management.Partners.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Management.Partners.Infrastructure.Configurations;

internal class DataSeed
{
    private static string _partner1Id;
    private static string _partner1Address1Id;

    public static void Up(MigrationBuilder migrationBuilder)
    {
        _partner1Id = Guid.NewGuid().ToString();
        migrationBuilder.InsertData(
            table: nameof(Partner),
            columns: new[] { nameof(Partner.Id), nameof(Partner.Name), nameof(Partner.Description) },
            values: new[] { _partner1Id, "Partner1", "Partner1 Description" });

        _partner1Address1Id = Guid.NewGuid().ToString();
        migrationBuilder.InsertData(
            table: nameof(Address),
            columns: new[] { nameof(Address.Id), nameof(Address.Name), nameof(Address.CountryCode), nameof(Address.ZipCode), nameof(Address.City), nameof(Address.AddressValue), nameof(Address.PartnerId) },
            values: new[] { _partner1Address1Id, "Partner1 Address1", "HU", "1037", "Budapest", "Montevideo u. 8", _partner1Id });
    }

    public static void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: nameof(Address),
            keyColumn: nameof(Address.Id),
            keyValue: _partner1Address1Id);

        migrationBuilder.DeleteData(
            table: nameof(Partner),
            keyColumn: nameof(Partner.Id),
            keyValue: _partner1Id);
    }
}
