using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookMusicApp.Models.Entities;

public class Artist
{
  [Key]
  public required int ArtistId { get; set; }
  public required string Name { get; set; }
  public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

}