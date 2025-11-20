using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Service
{
    internal interface IPlaybackService
    {
        void Play();
        void Stop();
        void Forward();
        void Backward();
        int ChangePlayList(string guid);
        MusicTrack CurrentMusicPlaying();
    }
}
