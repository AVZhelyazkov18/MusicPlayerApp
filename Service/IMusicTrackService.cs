using MusicPlayerApp.Models;

namespace MusicPlayerApp.Service
{
    public interface IMusicTrackService
    {
        List<MusicTrack> GetTracksByIds(List<string> trackIds);

        public Task<bool> CreateTrackFromData(string playlistId, string trackPath);
    }
}
