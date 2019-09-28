using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Enemies
{
    public interface IEnemy : IMoving, IEnemyState
    {
        float Speed { get; set; }

        new void Update(GameTime gameTime);

        new void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
