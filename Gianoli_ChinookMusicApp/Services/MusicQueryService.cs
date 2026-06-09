using System.Security.Cryptography.X509Certificates;
using Gianoli_ChinookMusicApp.Data;
using Gianoli_ChinookMusicApp.Models.Dtos;
using Gianoli_ChinookMusicApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Gianoli_ChinookMusicApp.Services;

public class MusicQueryService
{
  private readonly ApplicationDbContext _context;
  public MusicQueryService(ApplicationDbContext context)
  {
    _context = context;
  }

  // #1
  public async Task<List<Artist>> GetAllArtistsWithAlbums()
  {
    return await _context.Artist
      .Where(artist => artist.Albums.Count > 0)
      .Include(artist => artist.Albums)
      .ToListAsync();
  }
  // #2
  public async Task<List<Artist>> GetAllArtistsWithMoreThanOneAlbum()
  {
    return await _context.Artist
    .Where(artist => artist.Albums.Count > 1)
    .Include(artist => artist.Albums)
    .ToListAsync();
  }

  // #3
  public async Task<Artist?> GetArtistByNameWithAlbums(string artistName)
  {
    return await _context.Artist
      .Include(artist => artist.Albums)
      .SingleOrDefaultAsync(artist => artist.Name == artistName);
  }
  // #4
  public async Task<List<Track>> GetTracksByAlbumId(int albumId)
  {
    return await _context.Track
      .Where(Album => Album.AlbumId == albumId)
      .ToListAsync();
  }

  // TODO: Check all the following lines of code:
  // #5
  public async Task<List<Genre>> GetAllGenresWithTracks()
  {
    return await _context.Genre
      .Where(genre => genre.Tracks.Count > 0)
      .Include(genre => genre.Tracks)
      .ToListAsync();
  }
  //   // #6
  public async Task<List<Track>> GetTracksByGenreId(int genreId)
  {
    return await _context.Track
      .Where(track => track.GenreId == genreId)
      .ToListAsync();
  }
  //   // #7
  public async Task<List<StatisticDto>> GetTotalTracksByAlbum()
  {
    return await _context.Album
    .Select(album => new StatisticDto
    {
      Label = album.Title,
      Value = album.Tracks.Count()
    })
    .OrderBy(album => album.Label)
    .ToListAsync();
  }
  //   // #8
  public async Task<List<Album>> GetAlbumsByArtistId(int artistId)
  {
    return await _context.Album
      .Where(album => album.ArtistId == artistId)
      .ToListAsync();
  }
  //   // #9
  public async Task<List<Playlist>> GetAllPlaylistsWithTracks()
  {
    return await _context.Playlist
      .Where(playlist => playlist.Tracks.Count > 0)
      .Include(playlist => playlist.Tracks)
      .ToListAsync();
  }
  //   // #10
  public async Task<List<StatisticDto>> GetAverageDurationByGenre()
  {
    return await _context.Track
      .GroupBy(track => track.Genre.Name)
      .Select(group => new StatisticDto
      {
        Label = group.Key,
        Value = group.Average(track => track.Milliseconds / 1000.0m),
        ValueMetric = "seconds"
      })
      .ToListAsync();
  }
  //   // #11
  public async Task<List<Artist>> GetArtistsWithoutAlbums()
  {
    return await _context.Artist
      .Where(artist => artist.Albums.Count == 0)
      .ToListAsync();
  }
  //   // #12
  public async Task<List<Track>> GetTracksWithGenreAndAlbum()
  {
    return await _context.Track
      .Include(track => track.Genre)
      .Include(track => track.Album)
      .ToListAsync();

  }
  //   // #13
  public async Task<List<TrackDetailsDto>> GetTrackDetails()
  {
    return await _context.Track
      .Include(track => track.Album)
      .ThenInclude(album => album.Artist)
      .Select(track => new TrackDetailsDto
      {
        Track = track.Name,
        Album = track.Album.Title,
        Artist = track.Album.Artist.Name
      })
      .ToListAsync();
  }
  //   // #14
  public async Task<List<StatisticDto>> GetAlbumsWithTrackDuration()
  {
    return await _context.Album
      .Select(album => new StatisticDto
      {
        Label = album.Title,
        Value = album.Tracks.Sum(track => track.Milliseconds / 1000.0m),
        ValueMetric = "seconds"
      })
      .ToListAsync();
  }
  //   // #15
  public async Task<List<StatisticDto>> GetGenreTrackCounts()
  {
    return await _context.Genre
      .Select(genre => new StatisticDto
      {
        Label = genre.Name,
        Value = genre.Tracks.Count(),
        ValueMetric = "Tracks"
      })
      .ToListAsync();
  }
  //   // #16
  public async Task<List<StatisticDto>> GetPlaylistsWithTrackCount()
  {
    return await _context.Playlist
      .Select(playlist => new StatisticDto
      {
        Label = playlist.Name,
        Value = playlist.Tracks.Count(),
      })
      .ToListAsync();
  }
  //   // #17
  public async Task<List<Track>> GetTracksByPlaylistId(int playlistId)
  {
    return await _context.Playlist
      .Where(playlist => playlist.PlaylistId == playlistId)
      .SelectMany(playlist => playlist.Tracks)
      .ToListAsync();


  }
  //   // #18
  public async Task<Playlist?> GetPlaylistWithMostTracks()
  {
    return await _context.Playlist
      .OrderByDescending(p => p.Tracks.Count)
      .FirstOrDefaultAsync();
  }
  //   // #19
  public async Task<Playlist?> GetPlaylistWithLeastTracks()
  {
    return await _context.Playlist
  .OrderBy(p => p.Tracks.Count)
  .FirstOrDefaultAsync();
  }
  //   // #20
  public async Task<List<StatisticDto>> GetTopFivePlaylistsWithMostTracks()
  {
    return await _context.Playlist
      .OrderByDescending(p => p.Tracks.Count)
      .Take(5)
      .Select(p => new StatisticDto
      {
        Label = p.Name,
        Value = p.Tracks.Count,
        ValueMetric = "Tracks"
      })
      .ToListAsync();
  }
  //   // #21
  public async Task<List<StatisticDto>> GetBottomFivePlaylistsWithLeastTracks()
  {
    return await _context.Playlist
     .OrderBy(p => p.Tracks.Count)
     .Take(5)
     .Select(p => new StatisticDto
     {
       Label = p.Name,
       Value = p.Tracks.Count,
       ValueMetric = "Tracks"
     })
     .ToListAsync();
  }
  //   // #22
  // This Query finds the top 10 most expensive tracks in the Database
  // SELECT TOP 10
  //     Name,
  //     UnitPrice
  // FROM Track
  // ORDER BY UnitPrice DESC;
  public async Task<List<StatisticDto>> GetTopTenMostExpensiveTracks()
  {
    return await _context.Track
     .OrderByDescending(t => t.UnitPrice)
     .Take(10)
     .Select(t => new StatisticDto
     {
       Label = t.Name,
       Value = t.UnitPrice,
       ValueMetric = "Dollars"
     })
     .ToListAsync();
  }
  // // #23
  // This query returns the artists and their albums where the artist's name includes "Iron";
  // I modified it slightly to be reusable for any search term
  // SELECT
  //     Album.Title,
  //     Artist.Name
  // FROM Album
  // JOIN Artist
  //     ON Album.ArtistId = Artist.ArtistId
  // WHERE Artist.Name LIKE '%Iron%';
  public async Task<List<AlbumArtistDto>> AlbumsFromArtistSearch(string search)
  {
    return await _context.Album
     .Where(album => album.Artist!.Name.Contains(search))
     .Include(a => a.Artist)
     .Select(a => new AlbumArtistDto
     {
       AlbumTitle = a.Title,
       ArtistName = a.Artist!.Name
     })
     .ToListAsync();
  }
  // // #24
  // This query returns tracks longer than 5 minutes, along with their duration in seconds
  // SELECT
  //     Name,
  //     Milliseconds
  // FROM Track
  // WHERE Milliseconds > 300000;
  public async Task<List<StatisticDto>> TracksOverFiveMinutes()
  {
    return await _context.Track
      .Where(t => t.Milliseconds > 300000)
      .Select(t => new StatisticDto
      {
        Label = t.Name,
        Value = (decimal)t.Milliseconds / 1000,
        ValueMetric = "Seconds"
      })
      .ToListAsync();
  }
  // // #25
  // This query returns all album titles in alphabetical order
  //   SELECT
  //     Title
  // FROM Album
  // ORDER BY Title;
  public async Task<List<string>> AlbumsByTitle()
  {
    return await _context.Album
      .OrderBy(a => a.Title)
      .Select(a => a.Title)
      .ToListAsync();
  }
  // // #26
  // This query returns the track name and album for a specific album;
  // Again, I will be modifying it to work for any search term instead 
  // of hardcoding the search into the query
  //   SELECT
  //     Track.Name,
  //     Album.Title
  // FROM Track
  // JOIN Album
  //     ON Track.AlbumId = Album.AlbumId
  // WHERE Album.Title = 'Big Ones';
  public async Task<List<AlbumTrackDto>> TracksOnAlbum(string search)
  {
    return await _context.Track
      .Where(t => t.Album!.Title.Contains(search))
      .Select(t => new AlbumTrackDto
      {
        AlbumTitle = t.Album.Title,
        TrackName = t.Name
      })
      .ToListAsync();
  }

}