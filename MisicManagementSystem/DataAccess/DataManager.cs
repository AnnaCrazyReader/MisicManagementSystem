using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicManagementSystem.Models;

namespace MusicManagementSystem
{
    internal class DataManager
    {
        private MusicDbContext db;

        public DataManager()
        {
            db = new MusicDbContext();
        }

        // Методи для роботи з виконавцями
        public List<Artist> GetAllArtists()
        {
            return db.Artists.ToList();
        }

        public List<Artist> GetArtistsSorted(string sortField, bool ascending)
        {
            // Сортування за різними полями
            switch (sortField)
            {
                case "artist_name":
                    return ascending
                        ? db.Artists.OrderBy(a => a.artist_name).ToList()
                        : db.Artists.OrderByDescending(a => a.artist_name).ToList();
                case "country_origin":
                    return ascending
                        ? db.Artists.OrderBy(a => a.country_origin).ToList()
                        : db.Artists.OrderByDescending(a => a.country_origin).ToList();
                case "musical_genre":
                    return ascending
                        ? db.Artists.OrderBy(a => a.musical_genre).ToList()
                        : db.Artists.OrderByDescending(a => a.musical_genre).ToList();
                default:
                    return db.Artists.ToList();
            }
        }


        public List<Artist> FilterArtists(string name, string country, string genre)
        {
            var query = db.Artists.AsQueryable();

            // Застосовуємо фільтри, якщо вони вказані
            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.artist_name.Contains(name));

            if (!string.IsNullOrEmpty(country))
                query = query.Where(a => a.country_origin.Contains(country));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(a => a.musical_genre.Contains(genre));

            return query.ToList();
        }

        public void DeleteArtist(int artistId)
{
    // Находим артиста в базе данных
    var artist = db.Artists.Find(artistId);
    
    if (artist != null)
    {
        // Проверяем наличие связанных песен
        var songs = db.Songs.Where(s => s.artist_id == artistId).ToList();
        
        // Удаляем связанные песни (если есть)
        if (songs.Any())
        {
            db.Songs.RemoveRange(songs);
        }
        
        // Удаляем самого артиста
        db.Artists.Remove(artist);
        
        // Сохраняем изменения в базе данных
        db.SaveChanges();
    }
}

        // Аналогічні методи для пісень
        // ...

        // Метод для пошуку
        public List<Artist> SearchArtists(string searchTerm)
        {
            return db.Artists
                .Where(a => a.artist_name.Contains(searchTerm) ||
                            a.country_origin.Contains(searchTerm) ||
                            a.musical_genre.Contains(searchTerm))
                .ToList();
        }

        // Метод з розрахунковим полем (кількість пісень виконавця)
        public List<ArtistWithSongCount> GetArtistsWithSongCount()
        {
            return db.Artists
                .Select(a => new ArtistWithSongCount
                {
                    Artist = a,
                    SongCount = db.Songs.Count(s => s.artist_id == a.artist_id)
                })
                .ToList();
        }

       
        public List<SongViewModel> GetSongsSorted(string sortField, bool ascending)
        {
            // Базовий запит
            var query = db.Songs.Include("Artist").AsQueryable();

            // Сортування за різними полями
            switch (sortField)
            {
                case "track_name":
                    query = ascending
                        ? query.OrderBy(s => s.track_name)
                        : query.OrderByDescending(s => s.track_name);
                    break;
                case "album_title":
                    query = ascending
                        ? query.OrderBy(s => s.album_title)
                        : query.OrderByDescending(s => s.album_title);
                    break;
                case "artist_name":
                    query = ascending
                        ? query.OrderBy(s => s.Artist.artist_name)
                        : query.OrderByDescending(s => s.Artist.artist_name);
                    break;
            }

            // Перетворюємо результат у SongViewModel
            return query.Select(s => new SongViewModel
            {
                song_id = s.song_id,
                track_name = s.track_name,
                album_title = s.album_title,
                artist_name = s.Artist.artist_name,
                duration = s.duration,
                release_year = s.release_year,
                play_count = s.play_count,
                artist_id = s.artist_id,
                mp3_file_path = s.mp3_file_path
            }).ToList();
        }


        public List<SongViewModel> FilterSongs(string name, string album, int? artistId, int? fromYear, int? toYear)
        {
            var query = db.Songs.Include("Artist").AsQueryable();

            // Застосовуємо фільтри
            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.track_name.Contains(name));

            if (!string.IsNullOrEmpty(album))
                query = query.Where(s => s.album_title.Contains(album));

            if (artistId.HasValue)
                query = query.Where(s => s.artist_id == artistId.Value);

            if (fromYear.HasValue)
                query = query.Where(s => s.release_year >= fromYear.Value);

            if (toYear.HasValue)
                query = query.Where(s => s.release_year <= toYear.Value);

            return query.Select(s => new SongViewModel
            {
                song_id = s.song_id,
                track_name = s.track_name,
                album_title = s.album_title,
                artist_name = s.Artist.artist_name,
                duration = s.duration,
                release_year = s.release_year,
                play_count = s.play_count,
                artist_id = s.artist_id,
                mp3_file_path = s.mp3_file_path
            }).ToList();
        }

        public List<SongViewModel> SearchSongs(string searchTerm)
        {
            return db.Songs.Include("Artist")
                .Where(s => s.track_name.Contains(searchTerm) ||
                            s.album_title.Contains(searchTerm) ||
                            s.Artist.artist_name.Contains(searchTerm))
                .Select(s => new SongViewModel
                {
                    song_id = s.song_id,
                    track_name = s.track_name,
                    album_title = s.album_title,
                    artist_name = s.Artist.artist_name,
                    duration = s.duration,
                    release_year = s.release_year,
                    play_count = s.play_count,
                    artist_id = s.artist_id,
                    mp3_file_path = s.mp3_file_path
                })
                .ToList();
        }

        
        public List<SongViewModel> GetAllSongs()
        {
            return db.Songs.Include("Artist")
                .Select(s => new SongViewModel
                {
                    song_id = s.song_id,
                    track_name = s.track_name,
                    album_title = s.album_title,
                    artist_name = s.Artist.artist_name,
                    duration = s.duration,
                    release_year = s.release_year,
                    play_count = s.play_count,
                    artist_id = s.artist_id,
                    mp3_file_path = s.mp3_file_path
                })
                .ToList();
        }



        public void DeleteSong(int songId)
        {
            var song = db.Songs.Find(songId);
            if (song != null)
            {
                db.Songs.Remove(song);
                db.SaveChanges();
            }
        }

        // Расчетное поле - общая длительность песен исполнителя
        public Dictionary<int, TimeSpan> GetTotalDurationByArtist()
        {
            return db.Songs
                .GroupBy(s => s.artist_id)
                .ToDictionary(
                    g => g.Key,
                    g => new TimeSpan(g.Sum(s => s.duration.Ticks))
                );
        }
    }

    // Допоміжний клас для розрахункового поля
    public class ArtistWithSongCount
    {
        public Artist Artist { get; set; }
        public int SongCount { get; set; }
    }
}
