using Sprint5.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Enemies
{
    public class LakituSpriteFactory
    {
        public static LakituSpriteFactory Instance { get; } = new LakituSpriteFactory();

        private Texture2D lakituFloating;
        private Texture2D lakituThrowing;
        private Texture2D lakituBall;

        private LakituSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            lakituFloating = content.Load<Texture2D>("Enemies\\LakituFloating");
            lakituThrowing = content.Load<Texture2D>("Enemies\\LakituThrowing");
            lakituBall = content.Load<Texture2D>("Enemies\\LakituBalls");
        }

        public ISprite CreateLakituFloatingSprite()
        {
            return new StaticSprite(lakituFloating, 1, 2, lakituFloating.Width, lakituFloating.Height);
        }

        public ISprite CreateLakituThrowingSprite()
        {
            return new StaticSprite(lakituThrowing, 1, 2, lakituThrowing.Width, lakituThrowing.Height);
        }

        public ISprite CreateLakituBallSprite()
        {
            return new AnimatedSprite(lakituBall, 1, 2, 0.25);
        }
    }
}