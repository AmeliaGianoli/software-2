using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookEnhancedQueries.Models.Entities;

public class Genre
{
  [Key]
  public int GenreId { get; set; }
  public required string Name { get; set; }
  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}