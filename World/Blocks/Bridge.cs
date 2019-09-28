using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.World;

namespace Sprint5.World.Blocks
{
    public class Bridge : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "Bridge"; } }

        private ISprite sprite;

        public Bridge()
        {
            this.sprite = WorldElementSpriteFactory.Instance.CreateBridgeSprite();
            Collision = new BlockCollision();
        }

        public void Hit(IPlayer player)
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
