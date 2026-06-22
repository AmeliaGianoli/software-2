using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gianoli_ChinookEnhancedQueries.Models.Entities;

public class InvoiceLine
{
  [Key]
  public int InvoiceLineId { get; set; }
  [ForeignKey("Invoice")]
  public int InvoiceId { get; set; }
  public virtual Invoice? Invoice { get; set; }
  [ForeignKey("Track")]
  public int TrackId { get; set; }
  public virtual Track? Track { get; set; }
  public decimal UnitPrice { get; set; }
  public int Quantity { get; set; }

}