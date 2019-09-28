using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class BushLong : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite bushLongSprite;

        public BushLong()
        {
            bushLongSprite = WorldElementSpriteFactory.Instance.CreateBushLongSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            bushLongSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            bushLongSprite.Update(gameTime);
        }
    }
}

