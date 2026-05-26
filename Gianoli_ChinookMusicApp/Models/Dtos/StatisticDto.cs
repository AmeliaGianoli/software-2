namespace Gianoli_ChinookMusicApp.Models.Dtos;

public class StatisticDto
{
  public required string Label { get; set; }
  public decimal Value { get; set; }
  public string? ValueMetric { get; set; }
}