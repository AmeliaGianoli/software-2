using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookEnhancedQueries.Models.Entities;

public class Artist
{
  [Key]
  public int ArtistId { get; set; }
  public required string Name { get; set; }
  public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

}