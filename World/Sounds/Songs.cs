using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;

namespace Sprint5.World.Sounds
{
    public class Songs : SoundObjectFactory
    {
        public static Songs Instance { get; } = new Songs();
        private Songs()
        {

        }
        public void LoadSongs(ContentManager content)
        {
            marioSong = content.Load<Song>("Sounds\\smb_song");
            hurrySong = content.Load<Song>("Sounds\\smb_hurrysong");
            starSong = content.Load<Song>("Sounds\\smb_starman");
        }
        public void PlaySong()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(marioSong);
        }
        public void PlaySong(TimeSpan playPosition)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(marioSong, playPosition);
        }
        public void PlayHurrySong()
        {
            hurry = true;
            MediaPlayer.Play(hurrySong);
        }
        public void PlayStarSong()
        {
            starSongPlaying = true;
            MediaPlayer.Volume = 1.0f;
            MediaPlayer.Play(starSong);
        }

        public void TimeToHurry(int time)
        {
            if (time < 100)
            { 
                MediaPlayer.Stop();
                PlayHurrySong();
           }
        }
    }
}
