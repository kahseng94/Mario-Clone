using Sprint5.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites.Entities.Enemies;
using System;

namespace Sprint5.Entities.Enemies.Lakitu
{
    public class LakituThrowingState: IEnemyState, ILakituState
    {
        private Game1 game;
        private Lakitu lakitu;
        private ISprite lakituSprite;
        public bool thrown { get; set; }
        private bool overMario = true;
        public bool OverMario
        {
            get { return overMario; }
            set { overMario = value; }
        }
        private bool flip = false;
        public bool Flip
        {
            get { return flip; }
            set { flip = value; }
        }

        public LakituThrowingState(Game1 game, Lakitu lakitu)
        {
            this.game = game;
            this.lakitu = lakitu;
            lakituSprite = LakituSpriteFactory.Instance.CreateLakituThrowingSprite();
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
            if (Math.Abs(location.X - game.Mario.Position.X) > 3)
            {
                lakitu.State = new LakituFloatingState(game, lakitu);
                overMario = false;
            }
        }

        public bool AboveMario()
        {
            return overMario;
        }

        public void Throw()
        {
            thrown = true;
        }

        public void Update(GameTime gameTime)
        {
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

