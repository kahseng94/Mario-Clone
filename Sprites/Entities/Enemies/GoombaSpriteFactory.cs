using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Enemies
{
    public class GoombaSpriteFactory
    {
        public static GoombaSpriteFactory Instance { get; } = new GoombaSpriteFactory();

        private Texture2D goomba;
        private Texture2D goombaStomped;
        private Texture2D goombaFlipped;

        private GoombaSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            goomba = content.Load<Texture2D>("Enemies\\GoombaSprite");
            goombaStomped = content.Load<Texture2D>("Enemies\\GoombaStompedSprite");
            goombaFlipped = content.Load<Texture2D>("Enemies\\GoombaFlippedSprite");
        }

        public ISprite CreateGoombaIdleSprite()
        {
            return new AnimatedSprite(goomba, 1, 2, 0.25);
        }

        public ISprite CreateGoombaStompedSprite()
        {
            return new StaticSprite(goombaStomped, 1, 2, goombaStomped.Width, goombaStomped.Height);
        }

        public ISprite CreateGoombaFlippedSprite()
        {
            return new StaticSprite(goombaFlipped, 1, 2, goombaFlipped.Width, goombaFlipped.Height);
        }

        public ISprite CreateGoombaLeftMovingSprite()
        {
            return new AnimatedSprite(goomba, 1, 2, 0.5, 0f, -3f/16f);
        }

        public ISprite CreateGoombaRightMovingSprite()
        {
            return new AnimatedSprite(goomba, 1, 2, 0.5, 0f, -3f/16f);
        }
    }
}
