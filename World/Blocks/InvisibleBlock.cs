using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;

namespace Sprint5.World.Blocks
{
    public class InvisibleBlock : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "Invisible"; } }

        public InvisibleBlock()
        {
            Collision = new BlockCollision();
        }

        public void Hit(IPlayer player)
        {
           
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }
    }
}
