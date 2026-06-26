namespace Gianoli_BankApp.Models.Dtos;

public class CustomerSummaryDto
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int CreditScore { get; set; }
  public int NumAccounts { get; set; }
  public int NumCreditCards { get; set; }
}