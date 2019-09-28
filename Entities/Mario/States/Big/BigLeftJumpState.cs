using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigLeftJumpState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigLeftJumpState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigLeftJumpSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
        }

        public void Up()
        {
            // Apply jump force
            if (mario.Movement.IsOnGround(mario))
            {
                SoundEffects.Instance.PlayJumpSmallSound();
                mario.ApplyForce(Mario.Jump);
            }
        }

        public void Down()
        {
            mario.State = new BigLeftIdleState(mario);
        }

        public void Left()
        {
            // Apply left force
            mario.ApplyForce(mario.Movement.IsOnGround(mario) ? Mario.GroundLeft : Mario.AirLeft);
        }

        public void Right()
        {
            mario.State = new BigRightIdleState(mario);
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
        }

        public void UpReleased()
        {
            mario.State = new BigLeftIdleState(mario);
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
            mario.State = new SmallLeftJumpState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireLeftJumpState(mario);
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
