using Sprint5.Entities.Enemies;
using Sprint5.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites.Entities.Enemies;
using System;

namespace Sprint5.Entities.Enemies.Lakitu
{
    public class LakituFloatingState: IEnemyState, ILakituState
    {
        private Game1 game;
        private Lakitu lakitu;
        private ISprite lakituSprite;
        public bool overMario = false;
        public bool flip = false;
        public bool thrown { get; set; }

        public LakituFloatingState(Game1 game, Lakitu lakitu)
        {
            this.game = game;
            this.lakitu = lakitu;
            lakituSprite = LakituSpriteFactory.Instance.CreateLakituFloatingSprite();
        }

        public void ChangeDirection()
        {
            lakitu.Flip = true;
        }

        public void FinishDirection()
        {
            //No state change
        }

        public void BeFlipped()
        {
            //No state change
        }

        public void BeStomped()
        {
            //No state change
        }

        public bool IsAlive()
        {
            return true;
        }

        public void AboveMario(Vector2 location)
        {
            if (Math.Abs(location.X - game.Mario.Position.X) < 3)
            {
                lakitu.State = new LakituThrowingState(game, lakitu);
                overMario = true;
            }
        }

        public bool AboveMario()
        {
            return overMario;
        }

        public void Update(GameTime gameTime)
        {
            lakitu.MarioDistanceCollision.Handle(this.lakitu, game);
            lakitu.Movement.MoveEntity(lakitu, lakitu.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);
            AboveMario(lakitu.Position);
            lakituSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            lakituSprite.Draw(spriteBatch, location);
        }
    }
}
