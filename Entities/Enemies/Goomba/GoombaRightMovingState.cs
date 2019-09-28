using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Movement;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Goomba
{
    public class GoombaRightMovingState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;
        private Game1 game;

        public GoombaRightMovingState(Game1 game, Goomba goomba)
        {
            this.goomba = goomba;
            this.game = game;
            goombaSprite = GoombaSpriteFactory.Instance.CreateGoombaRightMovingSprite();
        }

        public void ChangeDirection()
        {
            goomba.State = new GoombaLeftMovingState(game, goomba);
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
            goomba.Movement = new DeadMovement(game);
        }

        public bool IsAlive()
        {
            return true;
        }

        public void Update(GameTime gameTime)
        {
            goomba.Movement.MoveEntity(goomba, goomba.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);
            
            goombaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location);
        }
    }
}
