using System.Text.Json.Serialization;

namespace MusicPlayerApp.Models
{
    public class MusicTrack
    {
        [JsonInclude]
        public string trackId { get; set; }
        [JsonInclude]
        public string trackTitle { get; set; }
        [JsonInclude]
        public string trackAlbum { get; set; }
        [JsonInclude]
        public DateTime trackDateAdded { get; set; }
        [JsonInclude]
        public TimeSpan trackDuration { get; set; }
        [JsonInclude]
        public string trackAbsolutePath { get; set; }

        public MusicTrack(string trackPath, string trackTitle, string trackAlbum, TimeSpan trackDuration, DateTime trackAdded) {
            trackId = Guid.NewGuid().ToString();
            this.trackAbsolutePath = trackPath;
            this.trackTitle = trackTitle;
            this.trackAlbum = trackAlbum;
            this.trackDateAdded = trackAdded;
            this.trackDuration = trackDuration;
        }
        [JsonConstructor]
        public MusicTrack() { }
    }
}
