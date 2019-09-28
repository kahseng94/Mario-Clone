using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigOnFlagState : IMarioState
    {
        public string Name { get { return "OnFlag"; } }

        private Mario mario;
        private ISprite sprite;

        public BigOnFlagState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigOnFlagSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
        }

        public void Up()
        {
        }

        public void Down()
        {
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void CauseDamage()
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
            mario.State = new BigRightRunState(mario);
        }

        public void ToBig()
        {
        }

        public void ToSmall()
        {
        }

        public void ToFire()
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
