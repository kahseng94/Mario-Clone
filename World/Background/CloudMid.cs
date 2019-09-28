using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class CloudMid : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite cloudMidSprite;

        public CloudMid()
        {
            cloudMidSprite = WorldElementSpriteFactory.Instance.CreateCloudMidSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            cloudMidSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            cloudMidSprite.Update(gameTime);
        }
    }
}
