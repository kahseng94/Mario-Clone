using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;

namespace Sprint5.World.Blocks
{
    public class Princess : IBlock
    {
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "Princess"; } }
        public float XDirection { get; set; } = 0;

        public Vector2 Position
        {
            get; set;
        }

        private ISprite sprite;

        public Princess()
        {
            Bounds = new Rectangle(0, 0, 1, 1);
            Collision = new BlockCollision();
            sprite = ItemSpriteFactory.Instance.CreatePrincessSprite();
        }

        public static void Consume()
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, new Vector2(location.X, location.Y - 0.5f));
        }

        public void Hit(IPlayer player)
        {
        }
    }
}
