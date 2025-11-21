using MusicPlayerApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace MusicPlayerApp.Service
{
    public interface IMusicTrackService
    {
        List<MusicTrack> GetTracksByIds(List<string> trackIds);

        MusicTrack GetTrackById(string trackId);

        public Task<bool> CreateTrackFromData(string playlistId, string trackPath);

        int GetOrderTrack(string playlistId, string trackId);
    }
}
