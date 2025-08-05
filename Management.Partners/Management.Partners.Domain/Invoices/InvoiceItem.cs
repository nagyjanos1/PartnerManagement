namespace Management.Partners.Domain.Invoices;

internal class InvoiceItem
{
    /// <summary>
    /// Név, amely a tétel nevét jelenti.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Bruttó egységár, amely a tétel egységárát jelenti.
    /// </summary>
    public decimal GrossUnitPrice { get; set; }

    /// <summary>
    /// Nettó egységár, amely a tétel egységárának adó nélküli értékét jelenti.
    /// </summary>
    public decimal NetUnitPrice { get; set; }

    /// <summary>
    /// Adó kulcs, amelyet a tételre alkalmaznak.
    /// </summary>
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Mennyiség, amely a tétel mennyiségét jelenti.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Nettó összeg, amely a tétel egységárának és mennyiségének szorzataként számítódik.
    /// </summary>
    public decimal Total => GrossUnitPrice * Quantity;

    /// <summary>
    /// Nettó összeg, amely a tétel egységárának és mennyiségének szorzataként számítódik, adó nélkül.
    /// </summary>
    public decimal NetTotal => NetUnitPrice * Quantity;
}