using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Goomba
{
    public class GoombaStompedState : IEnemyState
    {
        private ISprite goombaSprite;

        public GoombaStompedState()
        {
            goombaSprite = GoombaSpriteFactory.Instance.CreateGoombaStompedSprite();
        }

        public void ChangeDirection()
        {
            //NO OP
        }

        public void FinishDirection()
        {
        }

        public void BeFlipped()
        {
            //NO OP
        }

        public void BeStomped()
        {
            //NO OP
        }

        public bool IsAlive()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            goombaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location);
        }
    }
}
