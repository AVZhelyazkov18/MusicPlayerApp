using MusicPlayerApp.Models;
using System.Text.Json;

namespace MusicPlayerApp.Repository
{
    public class MusicTrackRepository : IMusicTrackRepository
    {
        private readonly string _dataAbsolutePath;
        private readonly string _tracksDataAbsolutePath;

        public MusicTrackRepository()
        {
            _dataAbsolutePath = Path.Combine(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
                "Data"
            );

            _tracksDataAbsolutePath = Path.Combine(
                _dataAbsolutePath,
                "musictracks.json"
            );
        }

        public List<MusicTrack> LoadMusicTracksFromJson()
        {
            try
            {
                string jsonText = File.ReadAllText(_tracksDataAbsolutePath);

                List<MusicTrack> playlists = JsonSerializer.Deserialize<List<MusicTrack>>(jsonText);

                return playlists;
            }
            catch (FileNotFoundException exc)
            {
                File.Create(_tracksDataAbsolutePath);

                return null;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public async Task<bool> SaveMusicTracksToJson(List<MusicTrack> tracks)
        {
            try
            {
                string jsonText = JsonSerializer.Serialize(tracks, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(_tracksDataAbsolutePath, jsonText);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
