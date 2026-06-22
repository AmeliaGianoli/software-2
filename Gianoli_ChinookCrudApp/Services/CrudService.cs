using System.Reflection.Metadata.Ecma335;
using Gianoli_ChinookCrudApp.Data;
// using Gianoli_ChinookCrudApp.Models.Dtos;
using Gianoli_ChinookCrudApp.Models.Entities;
// using Gianoli_ChinookCrudApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gianoli_ChinookCrudApp.Services;

public class CrudService
{
  private readonly ApplicationDbContext _context;

  public CrudService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Customer> AddCustomerAsync(string firstName, string lastName, string email, int supportRepId)
  {
    var customer = new Customer
    {
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      SupportRepId = supportRepId
    };
    _context.Customer.Add(customer);
    await _context.SaveChangesAsync();
    return customer;
  }

  public async Task<bool> UpdateTrackPriceAsync(int trackId, decimal newPrice)
  {
    var track = await _context.Track.FindAsync(trackId);
    if (track != null)
    {
      track.UnitPrice = newPrice;
      await _context.SaveChangesAsync();
      return true;
    }
    else
    {
      return false;
    }
  }

  public async Task<bool> DeletePlaylistAsync(int playlistId)
  {
    var playlist = await _context.Playlist.FindAsync(playlistId);

    if (playlist != null)
    {
      _context.Playlist.Remove(playlist);
      await _context.SaveChangesAsync();
      return true;
    }
    else
    {
      return false;
    }
  }

  public async Task<Album> CreateAlbumForArtistAsync(int artistId, string title)
  {
    var album = new Album { ArtistId = artistId, Title = title };
    _context.Album.Add(album);
    await _context.SaveChangesAsync();
    return album;
  }

  public async Task<int> UpdateTracksByComposerAsync(string composer, decimal newPrice)
  {
    var tracks = await _context.Track
      .Where(t => t.Composer == composer)
      .ToListAsync();
    foreach (Track track in tracks)
    {
      track.UnitPrice = newPrice;
    }
    await _context.SaveChangesAsync();
    return tracks.Count;
  }

  public async Task<int> DeleteCustomersByCountryAsync(string country)
  {
    var customers = await _context.Customer
      .Where(c => c.Country == country)
      .ToListAsync();
    _context.Customer.RemoveRange(customers);
    await _context.SaveChangesAsync();
    return customers.Count;
  }

  public async Task<int> AdjustTrackPricesByGenreAsync(int genreId, decimal percentIncrease)
  {
    var tracks = await _context.Track
      .Where(t => t.GenreId == genreId)
      .ToListAsync();
    foreach (Track track in tracks)
    {
      track.UnitPrice *= 1 + (percentIncrease / 100);
    }
    await _context.SaveChangesAsync();
    return tracks.Count;
  }

  public async Task<int> DeleteEmptyPlaylistsAsync()
  {
    var playlists = await _context.Playlist
      .Where(p => !p.Tracks.Any())
      .ToListAsync();
    _context.Playlist.RemoveRange(playlists);
    await _context.SaveChangesAsync();
    return playlists.Count;
  }

  public async Task<int> RenameComposerAsync(string oldName, string newName)
  {
    var tracks = await _context.Track
      .Where(t => t.Composer == oldName)
      .ToListAsync();

    foreach (Track t in tracks)
    {
      t.Composer = newName;
    }
    await _context.SaveChangesAsync();
    return tracks.Count;
  }

  public async Task<int> DeleteCustomersWithNoInvoicesAsync()
  {
    var customers = await _context.Customer
      .Where(c => !c.Invoices.Any())
      .ToListAsync();
    _context.Customer.RemoveRange(customers);
    await _context.SaveChangesAsync();
    return customers.Count;
  }

  public async Task<int> RenameAlbumsContainingKeywordAsync(string keyword, string appendText)
  {
    var albums = await _context.Album
      .Where(a => a.Title.Contains(keyword))
      .ToListAsync();
    foreach (Album a in albums)
    {
      a.Title = a.Title + appendText;
    }
    await _context.SaveChangesAsync();
    return albums.Count;
  }

  public async Task<int> DeleteTracksNotPurchasedAsync()
  {
    var tracks = await _context.Track
      .Where(t => !_context.InvoiceLine.Any(il => il.TrackId == t.TrackId))
      .ToListAsync();
    _context.Track.RemoveRange(tracks);
    await _context.SaveChangesAsync();
    return tracks.Count;
  }


}










