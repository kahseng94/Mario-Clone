using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigRightIdleState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigRightIdleState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigRightIdleSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
            mario.Walk();
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new BigRightJumpState(mario);
        }

        public void Down()
        {
            mario.State = new BigRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BigLeftIdleState(mario);
        }

        public void Right()
        {
            mario.State = new BigRightRunState(mario);
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
            mario.State = new SmallRightIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireRightIdleState(mario);
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
