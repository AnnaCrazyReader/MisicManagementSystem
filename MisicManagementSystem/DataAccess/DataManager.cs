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
                case "name":
                    return ascending
                        ? db.Artists.OrderBy(a => a.artist_name).ToList()
                        : db.Artists.OrderByDescending(a => a.artist_name).ToList();
                case "country":
                    return ascending
                        ? db.Artists.OrderBy(a => a.country_origin).ToList()
                        : db.Artists.OrderByDescending(a => a.country_origin).ToList();
                // Додайте інші поля для сортування
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

        // В класс DataManager добавьте методы для работы с песнями
        public List<Song> GetAllSongs()
        {
            return db.Songs.Include("Artist").ToList();
        }

        public List<Song> GetSongsSorted(string sortField, bool ascending)
        {
            // Сортировка по различным полям
            switch (sortField)
            {
                case "name":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.track_name).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.track_name).ToList();
                case "year":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.release_year).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.release_year).ToList();
                case "album":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.album_title).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.album_title).ToList();
                case "duration":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.duration).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.duration).ToList();
                case "plays":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.play_count).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.play_count).ToList();
                case "artist":
                    return ascending
                        ? db.Songs.Include("Artist").OrderBy(s => s.Artist.artist_name).ToList()
                        : db.Songs.Include("Artist").OrderByDescending(s => s.Artist.artist_name).ToList();
                default:
                    return db.Songs.Include("Artist").ToList();
            }
        }

        public List<Song> FilterSongs(string name, string album, int? artistId, int? fromYear, int? toYear)
        {
            var query = db.Songs.Include("Artist").AsQueryable();

            // Применяем фильтры, если они указаны
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

            return query.ToList();
        }

        public List<Song> SearchSongs(string searchTerm)
        {
            return db.Songs.Include("Artist")
                .Where(s => s.track_name.Contains(searchTerm) ||
                            s.album_title.Contains(searchTerm) ||
                            s.Artist.artist_name.Contains(searchTerm))
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
