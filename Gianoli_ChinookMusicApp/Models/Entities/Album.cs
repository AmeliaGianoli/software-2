using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gianoli_ChinookMusicApp.Models.Entities;

public class Album
{
  [Key]
  public required int AlbumId { get; set; }
  public required string Title { get; set; }
  [ForeignKey("Artist")]
  public int ArtistId { get; set; }
  public virtual Artist? Artist { get; set; }

  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}