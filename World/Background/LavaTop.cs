using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class LavaTop : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite bushSprite;

        public LavaTop()
        {
            bushSprite = WorldElementSpriteFactory.Instance.CreateLavaTopSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            bushSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            bushSprite.Update(gameTime);
        }
    }
}
