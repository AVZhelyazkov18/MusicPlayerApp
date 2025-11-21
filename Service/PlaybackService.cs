using MusicPlayerApp.Forms;
using MusicPlayerApp.Models;
using MusicPlayerApp.Service;
using WMPLib;

public class PlaybackService : IPlaybackService
{
    private readonly IPlaylistService _playlistService;
    private readonly IMusicTrackService _musicTrackService;


    private Playlist? _currentPlaylist;

    private int _currentTrackIndex = -1;
    private string? _currentTrackId;

    private bool _isPlaying;

    private readonly WindowsMediaPlayer _player;

    public PlaybackService(IPlaylistService playlistService,
                           IMusicTrackService musicTrackService)
    {
        _playlistService = playlistService;
        _musicTrackService = musicTrackService;

        _player = new WindowsMediaPlayer();
    }

    public WindowsMediaPlayer GetMediaPlayer()
    {
        return _player;
    }

    public void ChangePlaylist(string playlistId, string trackId)
    {
        if (_currentPlaylist != null && 
            _currentPlaylist.id == playlistId && 
            _currentTrackId == trackId)
                return;

        _currentPlaylist = _playlistService.GetPlaylistById(playlistId);

        if (_currentPlaylist == null || _currentPlaylist.trackIds.Count <= 0)
        {
            _currentPlaylist = null;
            _currentTrackIndex = -1;
            _currentTrackId = null;
            _isPlaying = false;
            _player.controls.stop();
            return;
        }

        int index = _musicTrackService.GetOrderTrack(playlistId, trackId);
        if (index < 0 || index >= _currentPlaylist.trackIds.Count)
            index = 0;

        _currentTrackIndex = index;

        MusicTrack track = _musicTrackService.GetTrackById(trackId);
        _currentTrackId = track.trackId;


        _isPlaying = true;
        PlayInternal(track);
    }

    public MusicTrack? CurrentMusicPlaying()
    {
        if (_currentPlaylist == null ||
            _currentTrackIndex < 0 ||
            _currentTrackIndex >= _currentPlaylist.trackIds.Count)
        {
            return null;
        }

        return _musicTrackService.GetTrackById(_currentTrackId);
    }

    public void TogglePlayPause()
    {
        if (_currentPlaylist == null || _currentTrackIndex < 0)
            return;

        if (_isPlaying)
        {
            _player.controls.pause();
            _isPlaying = false;
        }
        else
        {
            if (string.IsNullOrEmpty(_player.URL))
            {
                var track = CurrentMusicPlaying();
                if (track != null && _currentPlaylist != null && _currentTrackId != null)
                {
                    _currentTrackIndex = _musicTrackService.GetOrderTrack(_currentPlaylist.id, _currentTrackId);
                    PlayInternal(track);
                }
            }
            else
            {
                _player.controls.play();
                _isPlaying = true;
            }
        }
    }

    public void PlayNext()
    {
        if (_currentPlaylist == null || _currentPlaylist.trackIds.Count <= 0)
            return;

        if (_currentTrackIndex >= _currentPlaylist.trackIds.Count - 1)
            return;

        _currentTrackIndex++;

        var trackId = _currentPlaylist.trackIds[_currentTrackIndex];
        _currentTrackId = trackId;

        PlayInternal(_musicTrackService.GetTrackById(_currentTrackId));
    }

    public void PlayPrevious()
    {
        if (_currentPlaylist == null || _currentPlaylist.trackIds.Count <= 0)
            return;

        if (_currentTrackIndex <= 0)
            return;

        _currentTrackIndex--;
        
        var trackId = _currentPlaylist.trackIds[_currentTrackIndex];
        _currentTrackId = trackId;

        PlayInternal(_musicTrackService.GetTrackById(_currentTrackId));
    }

    // This is an internal play command to play only if a new song is hit.
    private void PlayInternal(MusicTrack track)
    {
        if (track == null || string.IsNullOrWhiteSpace(track.trackAbsolutePath))
            return;

        _player.controls.stop();

        _player.URL = track.trackAbsolutePath;
        _player.controls.play();
        _isPlaying = true;
    }
}
