using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;

namespace Sprint5.Entities
{
    public interface IEntity
    {
        Vector2 Position { get; set; }

        Rectangle Bounds { get; set; }

        ICollision Collision { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
