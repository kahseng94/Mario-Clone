using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Projectiles;
using Sprint5.Entities.World;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.World.Background;
using System;
using Sprint5.Achievements;

namespace Sprint5.Entities.Mario
{
    public class MarioFinish : MovingEntity, IPlayer
    {
        public new Vector2 Position
        {
            get { return mario.Position; }
            set { mario.Position = value; }
        }
        public new LVector2 Velocity
        {
            get { return mario.Velocity; }
            set { mario.Velocity = value; }
        }
        public new LVector2 Acceleration
        {
            get { return mario.Acceleration; }
            set { mario.Acceleration = value; }
        }
        public override Rectangle Bounds
        {
            get { return mario.Bounds; }
            set { mario.Bounds = value; }
        }
        public override sealed ICollision Collision
        {
            get { return mario.Collision; }
            set { mario.Collision = value; }
        }
        public IMarioState State
        {
            get { return mario.State; }
            set { mario.State = value; }
        }
        public string Name { get { return State.Name; } }

        private Mario mario;
        private Game1 game;
        private bool running = false;
        private bool hidden = false;
        private int hiddenInterval = 0;
        private ToadCastle castle = null;
        private Random rnd = new Random();

        public MarioFinish(Mario mario, Game1 game, IBackground flag) : base(mario.Position, mario.Velocity, mario.Acceleration)
        {
            this.mario = mario;
            mario.Position = new Vector2(flag.Position.X + 2.5f, mario.Position.Y);

            Collision = new FinishCollision();
            Movement = new FinishMovement(game);
            this.game = game;
            mario.UpReleased();
            mario.Right();

            if (mario.State.Name == "Big")
                mario.State = new BigOnFlagState(mario);
            else if (mario.State.Name == "Fire")
                mario.State = new FireOnFlagState(mario);
            else if (mario.State.Name == "Small")
                mario.State = new SmallOnFlagState(mario);

            foreach (IBackground ib in game.WorldLoader.Background)
                if (ib is ToadCastle) { castle = (ToadCastle)ib; break; }
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void Up()
        {
        }

        public void Down()
        {
        }

        public void UpReleased()
        {
        }

        public void DownReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void RightReleased()
        {
        }

        public void Use()
        {
        }

        public void Walk()
        {
        }

        public void Run()
        {
            mario.State.Run();
            running = true;
        }

        public void ToBig()
        {
        }

        public void ToSmall()
        {
        }

        public void ToFire()
        {
        }

        public void CauseDamage()
        {
        }

        public void Shoot()
        {
        }

        public new void Update(GameTime gameTime)
        {
            if (running)
            {
                if (game.HUD.Time >= 240)
                {
                    game.AchiTracker.UnlockSpeedRun();
                }

                if (Position.X < game.Map.Width - 6)
                {
                    mario.Position = new Vector2(Position.X + 0.05f, Position.Y);
                    Game1.Camera.PanCamera(2, game);
                    mario.Update(gameTime);
                }
                else
                {
                    mario.RightReleased();
                    hidden = true;
                }
                if (hidden)
                {
                    ++hiddenInterval;
                }
                if (hiddenInterval == 100)
                {
                    game.WorldLoader.Background.Add(new ToadCastleFlag() { Position = new Vector2(castle.Position.X + 2, 7.5f) });
                }
                if (hiddenInterval > 0 && hiddenInterval % 100 == 0)
                {
                    Fireball fire = new Fireball(game, new Vector2(rnd.Next((int)castle.Position.X - 1, (int)castle.Position.X + 6), rnd.Next(1, 6)), 0) { Interval = 100 };
                    game.WorldLoader.Fireballs.Add(fire);
                }

                if (hiddenInterval > 200)
                {
                    if (game.LevelName == "Level1-1")
                    {
                        game.AchiTracker.UpdateAchievement();
                        AchievementScreen.ShowAchievements(game, "Level1-4");
                    }

                    
                }
            }
            else
            {
                Position = new Vector2(Position.X, Position.Y + 0.1f);
                if (Position.Y - Bounds.Y >= 12)
                    Run();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!hidden)
                mario.Draw(spriteBatch, location);
        }
    }
}
