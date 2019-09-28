using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Projectile;

namespace Sprint5.Entities.Projectiles
{
    class Fireball : MovingEntity, IProjectile
    {
        private static Limit<Vector2> maxVelocity = new RectangleLimit(10, 10);
        private static Limit<Vector2> maxAcceleration = Limit<Vector2>.NONE;

        public override ICollision Collision { get; set; }
        public override Rectangle Bounds { get; set; }
        public int Interval { get; set; }

        private readonly Game1 game;

        private readonly Force direction;
        private readonly Force bounce = new Impulse(0, 5);
        private ISprite fireballSprite;
        private bool boom = false;
        public bool DisableGravity { get; set; } = false;


        public Fireball(Game1 game, Vector2 position, int direction) : base(position, new LVector2(maxVelocity), new LVector2(maxAcceleration))
        {
            this.game = game;
            this.direction = new SimpleForce(direction, 0);
            Movement = new EntityMovement(game);
            Collision = new ProjectileCollision();
            fireballSprite = FireballSpriteFactory.Instance.CreateFireballSprite();
            Bounds = new Rectangle(0, 0, 1, 1);
        }

        public void Attack(IEnemy enemy)
        {
            enemy.BeFlipped();
            enemy.Movement = new DeadMovement(game);
            Boom();
        }

        public void Boom()
        {
            Velocity = new LVector2(0.0f, 0.0f, Limit<Vector2>.NONE);
            //Bounds = new Rectangle();
            boom = true;
        }

        public void Bounce()
        {
            ApplyForce(bounce);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!boom)
            {
                fireballSprite.Draw(spriteBatch, location);
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (Interval == 1) Boom();
            else if (Interval > 1) --Interval;
            if (!boom)
            {
                if (Interval == 0 && !DisableGravity)
                {
                    ApplyForce(SimpleForce.gravity);
                }

                ApplyForce(direction);
                base.Update(gameTime);
                fireballSprite.Update(gameTime);
            }
        }
    }
}
