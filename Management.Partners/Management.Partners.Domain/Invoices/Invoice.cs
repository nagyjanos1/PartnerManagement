using Management.Partners.Domain.Partners;
using File = Management.Partners.Domain.Documents.File;

namespace Management.Partners.Domain.Invoices;

internal class Invoice
{
    public static Invoice None => new()
    {
        Id = Guid.Empty,
        Number = string.Empty,
        IssueDate = DateTime.MinValue,
        DueDate = DateTime.MinValue,
        Seller = Partner.None,
        BillTo = Partner.None,
        ShipTo = Address.None,
        Total = 0m,
        TaxRate = 0m,
        Discount = 0m,
        Subtotal = 0m,
        Comments = string.Empty,
        Items = null
    };

    public Guid Id { get; set; }

    /// <summary>
    /// Számla azonosítója.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Számla kiállításának dátuma.
    /// </summary>
    public DateTime IssueDate { get; set; }

    /// <summary>
    /// Számla esedékességének dátuma.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Eladó fél (eladó) adatai.
    /// </summary>
    public Partner Seller { get; set; }

    /// <summary>
    /// Vevő fél (vevő) adatai.
    /// </summary>
    public Partner BillTo { get; set; }

    /// <summary>
    /// Szállítási cím adatai.
    /// </summary>
    public Address ShipTo { get; set; }

    /// <summary>
    /// Teljes összeg, beleértve az adót és kedvezményeket.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Adó kulcs, amelyet a számlán alkalmaznak.
    /// </summary>
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Kedvezmény összege, amelyet a számlán alkalmaznak.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Nettó összeg, amely a teljes összegből levonva az adót.
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Pénznem, amelyben a számla kiállításra került (pl. HUF, EUR).
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Számla tételek listája.
    /// </summary>
    public IReadOnlyCollection<InvoiceItem> Items { get; set; } = [];

    /// <summary>
    /// Típus, amely meghatározza a számla típusát (Számla, Részszámla, Proforma, Sztornó)
    /// </summary>
    public InvoiceType Type { get; set; }

    /// <summary>
    /// Megjegyzés a számlához.
    /// </summary>
    public string Comments { get; set; }

    /// <summary>
    /// Feltöltött fájl, amely a számlához kapcsolódik (pl. PDF).
    /// </summary>
    public File UploadedFile { get; set; }
}
