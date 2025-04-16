using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagementSystem.Models
{
    public class SongViewModel
    {
        public int song_id { get; set; }
        public string track_name { get; set; }
        public string album_title { get; set; }
        public string artist_name { get; set; }
        public System.TimeSpan duration { get; set; }
        public int release_year { get; set; }
        public int play_count { get; set; }
        public int artist_id { get; set; }
        public string mp3_file_path { get; set; }
    }
}
