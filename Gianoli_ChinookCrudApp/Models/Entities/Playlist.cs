using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookCrudApp.Models.Entities;

public class Playlist
{
  [Key]
  public int PlaylistId { get; set; }
  public required string Name { get; set; }

  public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}