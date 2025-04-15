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
    }

    // Допоміжний клас для розрахункового поля
    public class ArtistWithSongCount
    {
        public Artist Artist { get; set; }
        public int SongCount { get; set; }
    }
}
