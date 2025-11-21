using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Service
{
    public interface IPlaylistService
    {
        public void RefreshPlaylistsData();
        public Task DeletePlaylistAsync(string guid);
        public Task CreatePlaylistAsync();
        public void RenamePlaylist(string guid, string newName);
        public List<Playlist> GetPlaylists();
        public List<string> GetMusicTrackIdsFromPlaylistId(string playlistId);
        public void AddMusicTrackToPlaylistId(string playlistId, string trackId);
    }
}
