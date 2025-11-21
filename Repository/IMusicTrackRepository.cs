using MusicPlayerApp.Models;

namespace MusicPlayerApp.Repository
{
    public interface IMusicTrackRepository
    {
        public List<MusicTrack> LoadMusicTracksFromJson();

        public Task<bool> SaveMusicTracksToJson(List<MusicTrack> tracks);
    }
}
