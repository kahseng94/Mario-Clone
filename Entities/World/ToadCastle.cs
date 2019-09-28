using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Background;

namespace Sprint5.Entities.World
{
    class ToadCastle : IBackground
    {
        public Vector2 Position { get; set; }

        private ISprite toadCastleSprite;

        public ToadCastle()
        {
            toadCastleSprite = WorldElementSpriteFactory.Instance.CreateToadCastleSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            toadCastleSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            toadCastleSprite.Update(gameTime);
        }
    }
}
