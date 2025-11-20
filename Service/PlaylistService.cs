using MusicPlayerApp.Models;
using MusicPlayerApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Service
{
    internal class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _repository;
        private List<Playlist> loadedPlaylists;
        public PlaylistService(IPlaylistRepository repository) {
            _repository = repository;
        }

        public void CreatePlaylist()
        {
            if (loadedPlaylists == null)
                loadedPlaylists = new List<Playlist>();

            loadedPlaylists.Add(new Playlist());

            bool taskResult = _repository.SavePlaylistsToFile(loadedPlaylists).Result;
            if (taskResult) {
                RefreshPlaylistsData();
            }
        }

        public void DeletePlaylist(string guid)
        {
            throw new NotImplementedException();
        }

        public void RefreshPlaylistsData()
        {
            List<Playlist> playlists = _repository.LoadPlaylistFromFile();

            if(playlists == null || playlists.Count <= 0)
                return;

            this.loadedPlaylists = playlists;
        }

        public void RenamePlaylist(string guid, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
