using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Models
{
    internal class MusicTrack
    {
        private string trackId { get; }
        private string trackTitle { get; }
        private string trackArtist { get; }
        private DateOnly trackReleaseDate;
        private string trackAbsolutePath;
    }
}
