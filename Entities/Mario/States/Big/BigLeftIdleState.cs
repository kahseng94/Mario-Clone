using Microsoft.Xna.Framework;
using Sprint5.Sprites.Entities.Mario;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigLeftIdleState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigLeftIdleState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigLeftIdleSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
            mario.Walk();
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new BigLeftJumpState(mario);
        }

        public void Down()
        {
            mario.State = new BigLeftCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BigLeftRunState(mario);
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
            mario.State = new FireLeftIdleState(mario);
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
