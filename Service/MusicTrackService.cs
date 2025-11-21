using MusicPlayerApp.Models;
using MusicPlayerApp.Repository;
using WMPLib;

namespace MusicPlayerApp.Service
{
    public class MusicTrackService : IMusicTrackService
    {
        private IMusicTrackRepository musicTrackRepository;
        private IPlaylistService playlistService;

        private List<MusicTrack> loadedTracks;

        public MusicTrackService(IMusicTrackRepository musicTrackRepository, IPlaylistService playlistService)
        {
            this.musicTrackRepository = musicTrackRepository;
            this.playlistService = playlistService;

            loadedTracks = musicTrackRepository.LoadMusicTracksFromJson();
        }

        public List<MusicTrack> GetTracksByIds(List<string> trackIds)
        {
            if (trackIds == null || loadedTracks == null)
                return null;

            if (loadedTracks.Count <= 0 || loadedTracks.Count <= 0)
                return null;

            return loadedTracks
                .Where(track => trackIds.Contains(track.trackId))
                .ToList();
        }

        public async Task<bool> CreateTrackFromData(string playlistId, string trackPath)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            IWMPMedia media = wmp.newMedia(trackPath);

            string title = string.IsNullOrEmpty(media.getItemInfo("Title")) ? "Unspecified" : media.getItemInfo("Title");
            string album = string.IsNullOrEmpty(media.getItemInfo("Album")) ? "Unspecified" : media.getItemInfo("Album");
            TimeSpan duration = TimeSpan.FromSeconds(media.duration);
            DateTime dateAdded = DateTime.Parse(media.getItemInfo("AcquisitionTime"));

            MusicTrack track = new MusicTrack(trackPath, title, album, duration, dateAdded);

            if(loadedTracks == null)
                loadedTracks = new List<MusicTrack>();

            loadedTracks.Add(track);
            playlistService.AddMusicTrackToPlaylistId(playlistId, track.trackId);

            bool result = await musicTrackRepository.SaveMusicTracksToJson(loadedTracks);
            return result;
        }
    }
}
