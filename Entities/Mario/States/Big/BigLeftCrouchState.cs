using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigLeftCrouchState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigLeftCrouchState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigLeftCrouchSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
            mario.Walk();
        }

        public void Up()
        {
            mario.State = new BigLeftIdleState(mario);
        }

        public void Down()
        {
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
            mario.State = new BigRightCrouchState(mario);
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
            mario.State = new BigLeftIdleState(mario);
        }

        public void UpReleased()
        {
        }

        public void Use()
        {
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
        }

        public void ToSmall()
        {
            SoundEffects.Instance.PlayPipeSound();
            mario.State = new SmallLeftIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireLeftCrouchState(mario);
        }

        public void CauseDamage()
        {
            //mario.State = new BigDeadState(mario);
            ToSmall();
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
