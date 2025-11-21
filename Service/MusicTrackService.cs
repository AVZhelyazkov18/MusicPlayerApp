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

        private WindowsMediaPlayer wmp;

        public MusicTrackService(IMusicTrackRepository musicTrackRepository, IPlaylistService playlistService)
        {
            this.musicTrackRepository = musicTrackRepository;
            this.playlistService = playlistService;
            this.wmp = new WindowsMediaPlayer();

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
        public MusicTrack GetTrackById(string trackId)
        {
            if (trackId == null || loadedTracks == null || loadedTracks.Count <= 0)
                return null;

            return loadedTracks
                .FirstOrDefault(track => track.trackId == trackId, null);
        }

        public async Task<bool> CreateTrackFromData(string playlistId, string trackPath)
        {
            IWMPMedia media = wmp.newMedia(trackPath);

            string title = string.IsNullOrEmpty(media.getItemInfo("Title")) ? "Unspecified" : media.getItemInfo("Title");
            string album = string.IsNullOrEmpty(media.getItemInfo("Album")) ? "Unspecified" : media.getItemInfo("Album");
            TimeSpan duration = TimeSpan.FromSeconds(media.duration);
            DateTime dateAdded;
            if(string.IsNullOrWhiteSpace(media.getItemInfo("AcquisitionTime")))
                dateAdded = DateTime.Now;
            else
                dateAdded = DateTime.Parse(media.getItemInfo("AcquisitionTime"));

            MusicTrack track = new MusicTrack(trackPath, title, album, duration, dateAdded);

            if(loadedTracks == null)
                loadedTracks = new List<MusicTrack>();

            loadedTracks.Add(track);
            playlistService.AddMusicTrackToPlaylistId(playlistId, track.trackId);

            bool result = await musicTrackRepository.SaveMusicTracksToJson(loadedTracks);
            return result;
        }

        public int GetOrderTrack(string playlistId, string trackId)
        {
            Playlist playlist = playlistService.GetPlaylistById(playlistId);

            if (playlist == null ||
                playlist.trackIds == null ||
                playlist.trackIds.Count <= 0)
                return -1;

            int index = playlist.trackIds.IndexOf(trackId);

            return index;
        }
    }
}
