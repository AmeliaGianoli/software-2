using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gianoli_BankApp.Models.Entities;

public class Customer
{
  [Key]
  public int CustId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime DOB { get; set; }
  public string Address { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string Country { get; set; }
  public string PostalCode { get; set; }
  public DateTime DateJoined { get; set; }
  public int CreditScore { get; set; }

  public ICollection<Account> Accounts { get; set; } = new List<Account>();
  public ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

}