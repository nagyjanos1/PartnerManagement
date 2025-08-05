namespace Management.Partners.Domain.Invoices;

public enum InvoiceType
{
    /// <summary>
    /// nincs típus, amely nem határoz meg semmilyen számlatípust.
    /// </summary>
    None, 

    /// <summary>
    /// Végszámla.
    /// </summary>
    Normal,

    /// <summary>
    /// Részszámla, amely a teljes összeg egy részét tartalmazza.
    /// </summary>    
    Partial,
    
    /// <summary>
    /// Proforma számla.
    /// </summary>
    Proforma,
    
    /// <summary>
    /// Stornó számla, amely a korábbi számla visszavonását jelenti.
    /// </summary>
    Storno
}