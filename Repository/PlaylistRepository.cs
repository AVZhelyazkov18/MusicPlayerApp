using MusicPlayerApp.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicPlayerApp.Repository
{
    internal class PlaylistRepository : IPlaylistRepository
    {
        private readonly string _playlistAbsolutePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

        public List<Playlist> LoadPlaylistFromFile()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SavePlaylistsToFile(List<Playlist> playlists)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(playlists);

                await File.WriteAllTextAsync(Path.Combine(_playlistAbsolutePath, "\\playlists.json"), jsonString);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
