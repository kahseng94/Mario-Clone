using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class Hill : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite hillSprite;

        public Hill()
        {
            hillSprite = WorldElementSpriteFactory.Instance.CreateHillSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            hillSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            hillSprite.Update(gameTime);
        }
    }
}
