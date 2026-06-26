using Gianoli_BankApp.Data;
using Gianoli_BankApp.Models.Entities;
using Gianoli_BankApp.Models.Dtos;

namespace Gianoli_BankApp.Services;

public class BankQueryService
{
  private readonly ApplicationDbContext _context;
  public BankQueryService(ApplicationDbContext context)
  {
    _context = context;
  }

}