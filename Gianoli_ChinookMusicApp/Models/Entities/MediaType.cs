using System.ComponentModel.DataAnnotations;

namespace Gianoli_ChinookMusicApp.Models.Entities;

public class MediaType
{
  [Key]
  public int MediaTypeId { get; set; }
  public string Name { get; set; }

}