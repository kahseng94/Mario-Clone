using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class Cloud : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite cloudSprite;

        public Cloud()
        {
            cloudSprite = WorldElementSpriteFactory.Instance.CreateCloudSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            cloudSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            cloudSprite.Update(gameTime);
        }
    }
}
