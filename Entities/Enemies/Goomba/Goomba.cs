using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.World.Sounds;
using Sprint5.Entities.Items;

namespace Sprint5.Entities.Enemies.Goomba
{
    public class Goomba : MovingEntity, IEnemy, IJumpingEnemy
    {
        private Game1 game;
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }
        public IEnemyState State { get; set; }
        public float Speed { get; set; }
        public Boolean Flip { get; set; }

        public Force Jump { get; set; } = new Impulse(0, .3f);

        public Goomba(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new EnemyCollision();
            Speed = 3;
            //State = new GoombaIdleState(this);
            State = new GoombaRightMovingState(game, this);
            Flip = false;
        }

        public void ApplyForce()
        {
            if (this.Movement.IsOnGround(this))
            {
                this.ApplyForce(Jump);
            }
        }

        public void ChangeDirection()
        {
            Flip = true;
        }

        public void FinishDirection()
        {
            if (Flip)
            {
                State.ChangeDirection();
                Flip = false;
            }
        }

        public void BeFlipped()
        {
            State.BeFlipped();
            game.HUD.GetScore(100);
            MovingText score = new MovingText(game, "100", Position);
            game.WorldLoader.MovingTexts.Add(score);
        }

        public void BeStomped()
        {
            State.BeStomped();
            game.HUD.GetScore(100);
            MovingText score = new MovingText(game, "100", Position);
            game.WorldLoader.MovingTexts.Add(score);
        }

        public bool IsAlive()
        {
            return State.IsAlive();
        }

        public new void Update(GameTime gameTime)
        {
            State.Update(gameTime);

            ApplyForce(SimpleForce.gravity);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location);
        }
        
    }
}
