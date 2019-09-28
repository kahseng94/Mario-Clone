using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Sprint5.World.Sounds
{
    class SoundEffects : SoundObjectFactory
    {
        public static SoundEffects Instance { get; } = new SoundEffects();
        private SoundEffects()
        {

        }
        public void LoadSoundEffects(ContentManager content)
        {
            oneUp = content.Load<SoundEffect>("Sounds\\smb_1-up");
            bowserFalls = content.Load<SoundEffect>("Sounds\\smb_bowserfalls");
            bowserFire = content.Load<SoundEffect>("Sounds\\smb_bowserfire");
            breakBlock = content.Load<SoundEffect>("Sounds\\smb_breakblock");
            bump = content.Load<SoundEffect>("Sounds\\smb_bump");
            coin = content.Load<SoundEffect>("Sounds\\smb_coin");
            fireball = content.Load<SoundEffect>("Sounds\\smb_fireball");
            fireworks = content.Load<SoundEffect>("Sounds\\smb_fireworks");
            flagpole = content.Load<SoundEffect>("Sounds\\smb_flagpole");
            gameover = content.Load<SoundEffect>("Sounds\\smb_gameover");
            jumpSmall = content.Load<SoundEffect>("Sounds\\smb_jump-small");
            jumpSuper = content.Load<SoundEffect>("Sounds\\smb_jump-super");
            kick = content.Load<SoundEffect>("Sounds\\smb_kick");
            marioDie = content.Load<SoundEffect>("Sounds\\smb_mariodie");
            pause = content.Load<SoundEffect>("Sounds\\smb_pause");
            pipe = content.Load<SoundEffect>("Sounds\\smb_pipe");
            powerUp = content.Load<SoundEffect>("Sounds\\smb_powerup");
            powerUpAppears = content.Load<SoundEffect>("Sounds\\smb_powerup_appears");
            stageClear = content.Load<SoundEffect>("Sounds\\smb_stage_clear");
            stomp = content.Load<SoundEffect>("Sounds\\smb_stomp");
            timeWarning = content.Load<SoundEffect>("Sounds\\smb_warning");
            vine = content.Load<SoundEffect>("Sounds\\smb_vine");
            worldClear = content.Load<SoundEffect>("Sounds\\smb_world_clear");
        }
        public void PlayOneUpSound()
        {
            oneUp.Play();
        }
        public void PlayBowserFallsSound()
        {
            bowserFalls.Play();
        }
        public void PlayBowserFireSound()
        {
            bowserFire.Play();
        }

        public void PlayBreakBlockSound()
        {
            breakBlock.Play();
        }
        public void PlayBumpSound()
        {
            bump.Play();
        }
        public void PlayCoinSound()
        {
            coin.Play();
        }
        public void PlayFireballSound()
        {
            fireball.Play();
        }
        public void PlayFireworksSound()
        {
            fireworks.Play();
        }
        public void PlayFlagpoleSound()
        {
            flagpole.Play();
        }
        public void PlayGameOverSound()
        {
            gameover.Play();
        }
        public void PlayJumpSmallSound()
        {
            jumpSmall.Play();
        }
        public void PlayJumpSuperSound()
        {
            jumpSuper.Play();
        }
        public void PlayKickSound()
        {
            kick.Play();
        }
        public void PlayMarioDieSound()
        {
            MediaPlayer.Stop();
            marioDie.Play();
        }
        public void PlayPauseSound()
        {
            pause.Play();
        }
        public void PlayPipeSound()
        {
            pipe.Play();
        }
        public void PlayPowerUpSound()
        {
            powerUp.Play();
        }
        public void PlayPowerUpAppearsSound()
        {
            powerUpAppears.Play();
        }
        public void PlayStageClearSound()
        {
            stageClear.Play();
        }
        public void PlayStompSound()
        {
            stomp.Play();
        }
        public void PlayTimeWarningSound()
        {
            timeWarning.Play();
        }
        public void PlayVineSound()
        {
            vine.Play();
        }
        public void PlayWorldClearSound()
        {
            worldClear.Play();
        }

    }
}
