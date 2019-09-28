using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Goomba
{
    public class GoombaIdleState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;
        private Game1 game;

        public GoombaIdleState(Game1 game, Goomba goomba)
        {
            this.goomba = goomba;
            this.game = game;
            goombaSprite = GoombaSpriteFactory.Instance.CreateGoombaIdleSprite();
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
            goomba.State = new GoombaFlippedState(game, goomba);
        }

        public void BeStomped()
        {
            goomba.State = new GoombaStompedState();
        }

        public bool IsAlive()
        {
            return true;
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
