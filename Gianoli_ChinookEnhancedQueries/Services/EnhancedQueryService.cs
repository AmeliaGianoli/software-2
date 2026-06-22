using Gianoli_ChinookEnhancedQueries.Models.Entities;
using Gianoli_ChinookEnhancedQueries.Models.Dtos;
using Gianoli_ChinookEnhancedQueries.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;

namespace Gianoli_ChinookEnhancedQueries.Services;

public class EnhancedQueryService
{
  private readonly ApplicationDbContext _context;

  public EnhancedQueryService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Dictionary<string, List<Customer>>> CustomersGroupedBySupportRepAsync()
  {
    var customers = await _context.Customer
      .Include(c => c.SupportRep)
      .ToListAsync();

    return customers
      .GroupBy(c => c.SupportRep!.Email!)
      .ToDictionary(
        g => g.Key,
        g => g.ToList()
      );
  }

  public async Task<Dictionary<string, List<Customer>>> GetCustomersByCountry()
  {
    return await _context.Customer
      .GroupBy(c => c.Country ?? "Unknown")
      .ToDictionaryAsync(
        c => c.Key,
        c => c.ToList()
      );
  }

  public async Task<Dictionary<string, int>> TrackCountByAlbumAsync()
  {
    return await _context.Track
    .GroupBy(t => t.Album!.Title)
    .ToDictionaryAsync(
      t => t.Key,
      t => t.Count()
    );
  }
  public async Task<List<AlbumStatDto>> TopThreeAlbumsMostTracks()
  {
    return await _context.Track
    .GroupBy(t => t.Album!.Title)
    .Select(t => new AlbumStatDto
    {
      Title = t.Key,
      TrackCount = t.Count()
    })
    .OrderByDescending(t => t.TrackCount)
    .Take(3)
    .ToListAsync();
  }

  public async Task<Dictionary<string, List<Track>>> TracksByComposer()
  {
    return await _context.Track
    .GroupBy(t => t.Composer ?? "Unknown")
    .ToDictionaryAsync(
      c => c.Key,
      c => c.ToList()
    );
  }

  public async Task<List<ComposerStatDto>> ComposersAndTracks()
  {
    return await _context.Track
    .GroupBy(t => t.Composer)
    .Select(t => new ComposerStatDto
    {
      Name = t.Key,
      TrackCount = t.Count()
    })
    .ToListAsync();
  }

  public async Task<List<Track>> GetTracksByGenreAsync(string genreName)
  {
    return await _context.Track
    .Where(t => t.Genre!.Name == genreName)
    .ToListAsync();
  }

  public async Task<List<Track>> GetTracksLongerThanAsync(int seconds)
  {
    return await _context.Track
    .Where(t => (t.Milliseconds / 1000) > seconds)
    .ToListAsync();
  }

  public async Task<List<TrackStatDto>> FiveMostExpensiveTracks()
  {
    return await _context.Track
    .Select(t => new TrackStatDto
    {
      Name = t.Name,
      Price = t.UnitPrice,
      AlbumTitle = t.Album!.Title
    })
    .OrderByDescending(t => t.Price)
    .Take(5)
    .ToListAsync();
  }

  public async Task<List<CustomerTransactionSummaryDto>> CustomersAndAmountSpent()
  {
    return await _context.Customer
    .Select(c => new CustomerTransactionSummaryDto
    {
      Id = c.CustomerId,
      FirstName = c.FirstName,
      LastName = c.LastName,
      TransactionTotal = c.Invoices.Sum(i => i.Total),
      TransactionCount = c.Invoices.Count()
    })
    .ToListAsync();
  }

  public async Task<List<CustomerTransactionSummaryDto>> CustomersToalPurchaseAmounts()
  {
    return await _context.Customer
    .Where(c => c.Invoices.Count() > 5)
       .Select(c => new CustomerTransactionSummaryDto
       {
         Id = c.CustomerId,
         FirstName = c.FirstName,
         LastName = c.LastName,
         TransactionTotal = c.Invoices.Sum(i => i.Total),
         TransactionCount = c.Invoices.Count()
       })
       .ToListAsync();
  }

  public async Task<List<CustomerTransactionSummaryDto>> CustomersWithMoreThanFivePurchases()
  {
    return await _context.Customer
    .Where(c => c.Invoices.Count() > 5)
       .Select(c => new CustomerTransactionSummaryDto
       {
         Id = c.CustomerId,
         FirstName = c.FirstName,
         LastName = c.LastName,
         TransactionTotal = c.Invoices.Sum(i => i.Total),
         TransactionCount = c.Invoices.Count()
       })
       .ToListAsync();
  }

  public async Task<Dictionary<int, List<Invoice>>> InvoicesGroupedByCustomerAsync()
  {
    return await _context.Invoice
    .GroupBy(i => i.CustomerId)
    .ToDictionaryAsync(
      i => i.Key,
      i => i.ToList()
    );
  }

  public async Task<List<CustomerTransactionSummaryDto>> GetTopCustomersBySpendingAsync(int count)
  {
    return await _context.Customer
      .Select(c => new CustomerTransactionSummaryDto
      {
        Id = c.CustomerId,
        FirstName = c.FirstName,
        LastName = c.LastName,
        TransactionTotal = c.Invoices.Sum(i => i.Total),
        TransactionCount = c.Invoices.Count()
      })
       .OrderByDescending(c => c.TransactionTotal)
       .Take(count)
       .ToListAsync();
  }

  public async Task<Dictionary<string, decimal>> RevenueByCountryAsync()
  {
    return await _context.Invoice
    .GroupBy(i => i.BillingCountry ?? "Unknown")
    .ToDictionaryAsync(
      i => i.Key,
      i => i.Sum(i => i.Total)
    );
  }

  public async Task<List<CountryTransactionSummaryDto>> TotalPurchasesByCountry()
  {
    return await _context.Invoice
    .GroupBy(i => i.BillingCountry ?? "Unknown")
      .Select(i => new CountryTransactionSummaryDto
      {
        Name = i.Key,
        TransactionCount = i.Count(),
        TransactionTotal = i.Sum(i => i.Total)
      })
      .ToListAsync();
  }

  public async Task<List<Customer>> GetCustomersByCountryAsync(string country)
  {
    return await _context.Customer
    .Where(c => c.Country == country)
    .ToListAsync();
  }

  public async Task<List<Invoice>> GetInvoicesInDateRangeAsync(DateTime startDate, DateTime endDate)
  {
    return await _context.Invoice
    .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate)
    .ToListAsync();
  }
}

