using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Projectiles;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies
{
    public class Bowser : MovingEntity, IEnemy
    {
        public float Speed { get; set; }

        public override Rectangle Bounds { get; set; } = new Rectangle(0, 0, 2, 2);

        public override ICollision Collision { get; set; }

        private int health = 2;
        private ISprite sprite = BowserSpriteFactory.Instance.CreateBowserIdleSprite();
        private Game1 game;
        private int time = 0;
        private int immune = 0;

        public Bowser(Game1 game, int x, int y) : base(new Vector2(x, y), LVector2.NONE, LVector2.NONE)
        {
            this.game = game;
            Movement = new EntityMovement(game);
        }

        public void BeFlipped()
        {
            if (immune <= 0)
            {
                immune = 100;
                --health;
            }
        }

        public void BeStomped()
        {
        }

        public void ChangeDirection()
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void FinishDirection()
        {
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public new void Update(GameTime gameTime)
        {
            if (immune > 0) --immune;
            if (health == 0)
            {
                health = -1;
                Velocity = new LVector2(0, 3, Physics.Vectors.Limits.Limit<Vector2>.NONE);
            }
            if (Position.Y < 6)
            {
                ApplyForce(new SimpleForce(0, -9));
            }
            sprite.Update(gameTime);
            time++;
            if (time % 200 == 0 && IsAlive())
            {
                game.WorldLoader.Fireballs.Add(new BowserFireball(game, new Vector2(Position.X - 2.1f, Position.Y), -1));
            }
            base.Update(gameTime);
        }
    }
}
