using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigRightCrouchState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigRightCrouchState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigRightCrouchSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
            mario.Walk();
        }

        public void Up()
        {
            mario.State = new BigRightIdleState(mario);
        }

        public void Down()
        {
            mario.State = new BigRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BigLeftCrouchState(mario);
        }

        public void Right()
        {
            if (!mario.Movement.IsOnGround(mario))
            {
                // Apply right force
                mario.ApplyForce(Mario.AirRight);
            }
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
            mario.State = new BigRightIdleState(mario);
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
            mario.State = new SmallRightIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireRightCrouchState(mario);
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
