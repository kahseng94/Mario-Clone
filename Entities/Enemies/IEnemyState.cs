using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Entities.Enemies
{
    public interface IEnemyState
    {
        void ChangeDirection();

        void FinishDirection();

        void BeStomped();

        void BeFlipped();

        bool IsAlive();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
