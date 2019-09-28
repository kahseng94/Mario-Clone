using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Entities.Projectiles;
using Sprint5.World.Pipes;
using Sprint5.World.Blocks;
using Sprint5.World.Sounds;
using Sprint5.Entities.Items;

namespace Sprint5.Entities.Mario
{
    public class Mario : MovingEntity, IPlayer
    {
        private static Limit<Vector2> MaxWalkVelocity = new RectangleLimit(10, 20);
        private static Limit<Vector2> MaxRunVelocity = new RectangleLimit(15, 20);
        private static Limit<Vector2> MaxAcceleration = Limit<Vector2>.NONE;
        private static Force GroundFriction = new FrictionForce(0.2f, 0);
        private static Force AirFriction = new FrictionForce(0.025f, 0);
        public static Force Jump { get; set; } = new Impulse(0, 0.4f);
        public static Force GroundLeft { get; set; } = new SimpleForce(-2, 0);
        public static Force GroundRight { get; set; } = new SimpleForce(2, 0);
        public static Force AirLeft { get; set; } = new SimpleForce(-0.4f, 0);
        public static Force AirRight { get; set; } = new SimpleForce(0.4f, 0);

        private const int DAMAGE_IMMUNITY_DURATION = 100;

        private int damageImmunityTimer = 0;

        private Game1 game;

        public override Rectangle Bounds { get; set; }

        public override sealed ICollision Collision { get; set; }

        public IMarioState State { get; set; }

        public string Name { get { return State.Name; } }

        public int Direction { get; set; }

        public Mario(Game1 game, int x, int y) : base(new Vector2(x, y), new LVector2(MaxWalkVelocity), new LVector2(MaxAcceleration))
        {
            this.game = game;
            Movement = new EntityMovement(game);
            Collision = new PlayerCollision();
            State = new SmallRightIdleState(this);
            Direction = 1;
        }

        public void Left()
        {
            State.Left();
            Direction = -1;
        }

        public void Right()
        {
            State.Right();
            Direction = 1;

            // check if there is a pipe that we may enter
            IBlock b = game.Map.GetBlock((int)Position.X + 1, (int)Position.Y);
            if (b is Pipe && ((Pipe)b).Side == Side.LEFT)
                (b as Pipe).Enter();
        }

        public void Up()
        {
            State.Up();
        }

        public void Down()
        {
            State.Down();

            // check if there is a pipe that we may enter
            IBlock b = game.Map.GetBlock((int)Position.X + 1, (int)Position.Y + 1);
            if (b is Pipe && ((Pipe)b).Side == Side.TOP)
                (b as Pipe).Enter();
        }

        public void UpReleased()
        {
            State.UpReleased();
        }

        public void DownReleased()
        {
            State.DownReleased();
        }

        public void LeftReleased()
        {
            State.LeftReleased();
        }

        public void RightReleased()
        {
            State.RightReleased();
        }

        public void Use()
        {
            State.Use();
        }

        public void Walk()
        {
            Velocity = new LVector2(Velocity.Vector, MaxWalkVelocity);
        }

        public void Run()
        {
            Velocity = new LVector2(Velocity.Vector, MaxRunVelocity);
        }

        private int fireballCoolDown = 20;

        public void Shoot()
        {
            if (fireballCoolDown <= 0)
            {
                SoundEffects.Instance.PlayFireballSound();
                Fireball fireball = new Fireball(game, Position, Direction);
                game.WorldLoader.Fireballs.Add(fireball);
                fireballCoolDown = 20;
            }
        }

        public void ToBig()
        {
            State.ToBig();
        }

        public void ToSmall()
        {
            State.ToSmall();
        }

        public void ToFire()
        {
            State.ToFire();
        }

        public void CauseDamage()
        {
            if (damageImmunityTimer == 0) // check if damage immunity is enabled
                State.CauseDamage();

            game.Mario = new MarioStar(game, this, 1000, false);

            if (State.Name != "Dead")
                damageImmunityTimer = DAMAGE_IMMUNITY_DURATION;
            else
            {
                Movement = new DeadMovement(game);
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (fireballCoolDown > 0) --fireballCoolDown;

            if (damageImmunityTimer > 0) --damageImmunityTimer;
            State.Update(gameTime);

            // Apply gravity force
            ApplyForce(SimpleForce.gravity);

            // Apply friction force
            ApplyForce((Movement.IsOnGround(this) ? GroundFriction : AirFriction));

            if (Position.Y >= 14)
            {
                // game over
                Game1.Lives--;
                game.Reset();
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            State.Draw(spriteBatch, vector);
        }
    }
}
