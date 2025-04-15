using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagementSystem.Models
{
    public class Artist
    {
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        public string country_origin { get; set; }
        public int birth_year { get; set; }
        public string musical_genre { get; set; }
        public string profile_photo { get; set; }

        // Зв'язок один-до-багатьох
        public virtual List<Song> Songs { get; set; }
    }
}
