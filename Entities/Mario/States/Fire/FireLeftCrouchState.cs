using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class FireLeftCrouchState : IMarioState
    {
        public string Name { get { return "Fire"; } }

        private Mario mario;
        private ISprite sprite;

        public FireLeftCrouchState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateFireLeftCrouchSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
            mario.Walk();
        }

        public void Up()
        {
            mario.State = new FireLeftIdleState(mario);
        }

        public void Down()
        {
            mario.State = new FireLeftCrouchState(mario);
        }

        public void Left()
        {
            if (!mario.Movement.IsOnGround(mario))
            {
                // Apply left force
                mario.ApplyForce(Mario.AirLeft);
            }
        }

        public void Right()
        {
            mario.State = new FireRightCrouchState(mario);
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
            mario.State = new FireLeftIdleState(mario);
        }

        public void UpReleased()
        {
        }

        public void Use()
        {
            mario.Shoot();
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
            mario.State = new BigLeftCrouchState(mario);
        }

        public void ToSmall()
        {
            SoundEffects.Instance.PlayPipeSound();
            mario.State = new SmallLeftIdleState(mario);
        }

        public void ToFire()
        {
        }

        public void CauseDamage()
        {
            //mario.State = new FireDeadState(mario);
            ToBig();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
