using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class SmallRightIdleState : IMarioState
    {
        public string Name { get { return "Small"; } }

        private Mario mario;
        private ISprite sprite;

        public SmallRightIdleState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateSmallRightIdleSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
            mario.Walk();
        }

        public void Left()
        {
            mario.State = new SmallLeftIdleState(mario);
        }

        public void Right()
        {
            mario.State = new SmallRightRunState(mario);
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new SmallRightJumpState(mario);
        }

        public void Down()
        {
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
            mario.State = new BigRightIdleState(mario);
        }

        public void ToSmall()
        {
        }

        public void ToFire()
        {
            mario.State = new FireRightIdleState(mario);
        }

        public void CauseDamage()
        {
            SoundEffects.Instance.PlayMarioDieSound();
            mario.State = new SmallDeadState(mario);
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
