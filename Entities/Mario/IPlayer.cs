using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Mario
{
    public interface IPlayer : IMoving, IMarioState
    {
        IMarioState State { get; set; }

        void Shoot();

        new void Update(GameTime gameTime);

        new void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
