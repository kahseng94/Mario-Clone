using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Enemies
{
    public class BowserSpriteFactory
    {
        public static BowserSpriteFactory Instance { get; } = new BowserSpriteFactory();

        private Texture2D bowser;

        private BowserSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bowser = content.Load<Texture2D>("Level 1-4\\bowser");
        }

        public ISprite CreateBowserIdleSprite()
        {
            return new AnimatedSprite(bowser, 1, 4, 0.25);
        }

        public static ISprite CreateBowserStompedSprite()
        {
            return GoombaSpriteFactory.Instance.CreateGoombaStompedSprite();
        }
    }
}
