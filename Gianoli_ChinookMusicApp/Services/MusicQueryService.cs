using System.Security.Cryptography.X509Certificates;
using Gianoli_ChinookMusicApp.Data;
using Gianoli_ChinookMusicApp.Models.Dtos;
using Gianoli_ChinookMusicApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
  //   public async Task<> GetAlbumsWithTrackDuration() { }
  //   // #15
  //   public async Task<> GetGenreTrackCounts() { }
  //   // #16
  //   public async Task<> GetPlaylistsWithTrackCount() { }
  //   // #17
  //   public async Task<> GetTracksByPlaylistId(int playlistId) { }
  //   // #18
  //   public async Task<> GetPlaylistWithMostTracks() { }
  //   // #19
  //   public async Task<> GetPlaylistWithLeastTracks() { }
  //   // #20
  //   public async Task<> GetTopFivePlaylistsWithMostTracks() { }
  //   // #21
  //   public async Task<> GetBottomFivePlaylistsWithLeastTracks() { }
  //   // #22
  //   public async Task<>
  // // #23
  // public async Task<>
  // // #24
  // public async Task<>
  // // #25
  // public async Task<>
  // // #26
  // public async Task<>

}