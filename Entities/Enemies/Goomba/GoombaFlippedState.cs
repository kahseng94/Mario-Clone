using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;
using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Enemies.Goomba
{
    public class GoombaFlippedState : IEnemyState
    {
        private Goomba goomba;
        private ISprite goombaSprite;
        private Game1 game;

        public GoombaFlippedState(Game1 game, Goomba goomba)
        {
            this.goomba = goomba;
            this.game = game;
            goombaSprite = GoombaSpriteFactory.Instance.CreateGoombaFlippedSprite();
        }

        public bool MovingRight()
        {
            return false;
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
            goomba.Movement = new DeadMovement(game);
        }

        public void BeStomped()
        {
            goomba.Movement = new DeadMovement(game);
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
