using Sprint5.Entities;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Projectiles;
using Sprint5.Sprites.Entities.Enemies;
using System;

namespace Sprint5.Entities.Enemies.Lakitu
{
    class LakituBall: MovingEntity, IEnemy, ILakituProjectile
    {
        private static Limit<Vector2> maxVelocity = new RectangleLimit(10, 10);
        private static Limit<Vector2> maxAcceleration = Limit<Vector2>.NONE;

        public override ICollision Collision { get; set; }
        public override Rectangle Bounds { get; set; }

        public Boolean flip { get; set; }

        private Game1 game;

        private Force direction;
        private readonly Force bounce = new Impulse(0, 5);
        private ISprite lakituBallSprite;
        public float Speed { get; set; }
        public LakituBall(Game1 game, Vector2 position, int direction) : base(position, new LVector2(maxVelocity), new LVector2(maxAcceleration))
        {
            this.game = game;
            this.direction = new SimpleForce(direction, 0);
            Movement = new EntityMovement(game);
            Collision = new LakituProjectileCollision();
            lakituBallSprite = LakituSpriteFactory.Instance.CreateLakituBallSprite();
            Bounds = new Rectangle(0, 0, 1, 1);
            flip = false;
            Speed = direction;
        }

        public void Bounce()
        {
            ApplyForce(bounce);
        }

        public bool IsAlive()
        {
            return true;
        }

        public void BeFlipped()
        {

        }

        public void BeStomped()
        {

        }

        public void FinishDirection()
        {
            if (flip)
            {
                Speed *= -1;
                this.direction = new SimpleForce(Speed, 0);
                flip = false;
            }
        }

        public void ChangeDirection()
        {
            flip = true;
        }


        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            lakituBallSprite.Draw(spriteBatch, location);
        }

        public new void Update(GameTime gameTime)
        {
            ApplyForce(SimpleForce.gravity);
            ApplyForce(direction);
            base.Update(gameTime);
            lakituBallSprite.Update(gameTime);
        }

    }
}
