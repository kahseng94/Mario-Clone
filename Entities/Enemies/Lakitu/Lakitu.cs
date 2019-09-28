using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Enemies.Lakitu
{
    public class Lakitu : MovingEntity, IEnemy
    {
        private Game1 game;
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }

        public LakituCollision MarioDistanceCollision { get; set; }
        public ILakituState State { get; set; }
        public float Speed { get; set; }
        public Boolean Flip { get; set; }

        public bool Left { get; set; }

        public Lakitu(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new LakituCollision();
            MarioDistanceCollision = new LakituCollision();
            Speed = 5;
            Flip = false;
            Left = false;
            State = new LakituFloatingState(game, this);
        }
        public void ChangeDirection()
        {
            Flip = true;
        }

        public void FinishDirection()
        {
            if (Flip)
            {
                Speed *= -1;
                Flip = false;
            }

        }
        public void BeFlipped()
        {
            //Can't be flipped
        }

        public void BeStomped()
        {
            //Can't be stomped
        }

        public bool IsAlive()
        {
            return true;
        }

        public bool AboveMario()
        {
            return State.AboveMario();
        }

        public new void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location);
        }

    }
}
