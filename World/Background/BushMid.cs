using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Background
{
    public class BushMid : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite bushMidSprite;

        public BushMid()
        {
            bushMidSprite = WorldElementSpriteFactory.Instance.CreateBushMidSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            bushMidSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            bushMidSprite.Update(gameTime);
        }
    }
}

