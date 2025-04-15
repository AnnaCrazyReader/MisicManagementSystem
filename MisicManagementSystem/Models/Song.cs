using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagementSystem.Models
{
    public class Song
    {
        public int song_id { get; set; }
        public string track_name { get; set; }
        public int release_year { get; set; }
        public TimeSpan duration { get; set; }
        public int play_count { get; set; }
        public string album_title { get; set; }

        // Зовнішній ключ
        public int artist_id { get; set; }
        public virtual Artist Artist { get; set; }

    }
}
