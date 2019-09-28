using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Achievements;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Items;
using Sprint5.Physics.Vectors;
using Sprint5.World.Blocks;

namespace Sprint5.Entities.Mario
{
    public class MarioFinishCastle : MovingEntity, IPlayer
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

        private IPlayer mario;
        private Game1 game;
        private Princess princess;
        private bool running = true;
        private bool meetPrincess = false;
        private int interval = 0;

        public MarioFinishCastle(Game1 game, Princess princess) : base(game.Mario.Position, game.Mario.Velocity, game.Mario.Acceleration)
        {
            if (game.Mario is MarioFinishCastle) return;
            this.mario = game.Mario;
            Collision = new FinishCollision();
            Movement = new FinishMovement();
            this.game = game;
            this.princess = princess;
            mario.UpReleased();
            mario.Right();
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
            // game.WorldLoader.LoadWorld("Level1-1", game, false);
            game.AchiTracker.UpdateAchievement();
            AchievementScreen.ShowAchievements(game, "Level1-1");
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
                if (Position.X < princess.Position.X - 1)
                {
                    mario.Position = new Vector2(Position.X + 0.05f, Position.Y);
                    Game1.Camera.PanCamera(2, game);
                    mario.Update(gameTime);
                }
                else
                {
                    mario.RightReleased();
                    meetPrincess = true;
                }
                if (meetPrincess)
                {
                    ++interval;
                }
                if (interval == 1)
                {
                    TextItem.game = game;
                    game.WorldLoader.Texts.Add(new TextItem("THANK YOU MARIO!", new Vector2(372, 192)));
                }
                if (interval == 100)
                {
                    game.WorldLoader.Texts.Add(new TextItem("CONGRATULATION! \nYOUR QUEST IS OVER.", new Vector2(372, 224)));
                }
                if (interval > 500)
                {
                    //if (game.worldLoader.LevelName == "Level1-1")
                    //    game.worldLoader.LoadWorld("Level1-4", game);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            mario.Draw(spriteBatch, location);
        }
    }
}
