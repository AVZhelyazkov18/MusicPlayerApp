using MusicPlayerApp.Models;
using WMPLib;

namespace MusicPlayerApp.Service
{
    public interface IPlaybackService
    {
        void ChangePlaylist(string playlistId, string trackId);
        void TogglePlayPause();
        void PlayNext();
        void PlayPrevious();

        WindowsMediaPlayer GetMediaPlayer();
        MusicTrack? CurrentMusicPlaying();
    }
}
