using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Service
{
    internal interface IPlaylistService
    {
        public void RefreshPlaylistsData();

        public void DeletePlaylist(string guid);

        public void CreatePlaylist();

        public void RenamePlaylist(string guid, string newName);
    }
}
