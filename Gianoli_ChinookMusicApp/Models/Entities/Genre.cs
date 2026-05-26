using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookMusicApp.Models.Entities;

public class Genre
{
  [Key]
  public required int GenreId { get; set; }
  public string Name { get; set; }
  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}