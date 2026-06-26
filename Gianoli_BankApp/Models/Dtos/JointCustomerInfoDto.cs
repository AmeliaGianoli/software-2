namespace Gianoli_BankApp.Models.Dtos;

public class JointCustomerInfoDto
{
  public int CustomerId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int CreditScore { get; set; }
  public DateTime DateOfBirth { get; set; }
  public int CustomerAge { get; set; }
  public int JointAccountId { get; set; }
  public string AccountType { get; set; }
  public decimal JointAccountBalance { get; set; }
}