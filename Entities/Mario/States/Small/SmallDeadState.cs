using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;

namespace Sprint5.Entities.Mario
{
    public class SmallDeadState : IMarioState
    {
        public string Name { get { return "Dead"; } }

        private Mario mario;
        private ISprite sprite;

        public SmallDeadState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateSmallDeadSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void Up()
        {
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
            mario.State = new SmallRightIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireRightIdleState(mario);
        }

        public void CauseDamage()
        {
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
