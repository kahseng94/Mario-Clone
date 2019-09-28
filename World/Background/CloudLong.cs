using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class CloudLong : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite cloudLongSprite;

        public CloudLong()
        {
            cloudLongSprite = WorldElementSpriteFactory.Instance.CreateCloudLongSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            cloudLongSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            cloudLongSprite.Update(gameTime);
        }
    }
}
