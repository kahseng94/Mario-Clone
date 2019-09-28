using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Items;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class Koopa : MovingEntity, IEnemy
    {
        private Game1 game;
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }
        public IEnemyState State { get; set; }
        public float Speed { get; set; }
        public bool Flip { get; set; }

        public Force Jump { get; set; } = new Impulse(0, .3f);

        public Koopa(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new EnemyCollision();
            Speed = 2;
            State = new KoopaLeftMovingState(game, this);
            Flip = false;
        }

        public void ApplyForce()
        {
            if (this.Movement.IsOnGround(this))
            {
                this.ApplyForce(Jump);
            }
        }

        public bool IsAlive()
        {
            return State.IsAlive();
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

        public void ChangeDirection()
        {
            Flip = true;
            //State.ChangeDirection();
        }

        public void FinishDirection()
        {
            if (Flip)
            {
                State.ChangeDirection();
                Flip = false;
            }
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
