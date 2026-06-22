namespace Gianoli_ChinookEnhancedQueries.Models.Dtos;

public class CustomerTransactionSummaryDto
{
  public int Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public decimal TransactionTotal { get; set; }
  public int TransactionCount { get; set; }
}