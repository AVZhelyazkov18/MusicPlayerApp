using MusicPlayerApp.Forms;
using MusicPlayerApp.Repository;
using MusicPlayerApp.Service;

namespace MusicPlayerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IPlaylistRepository playlistRepo = new PlaylistRepository();
            IPlaylistService playlistService = new PlaylistService(playlistRepo);

            IMusicTrackRepository trackRepository = new MusicTrackRepository();
            IMusicTrackService trackService = new MusicTrackService(trackRepository, playlistService);

            Application.Run(new MusicPlayerForm(playlistService, trackService));
        }
    }
}