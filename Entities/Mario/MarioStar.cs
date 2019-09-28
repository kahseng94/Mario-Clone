using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Vectors;
using Sprint5.World.Sounds;
using System;

namespace Sprint5.Entities.Mario
{
    public class MarioStar : MovingEntity, IPlayer
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

        private int duration;
        private static TimeSpan playPosition;

        public MarioStar(Game1 game, IPlayer mario, int duration, bool power) : base(mario.Position, mario.Velocity, mario.Acceleration)
        {
            this.game = game;
            this.mario = mario;
            this.duration = duration;

            Movement = new EntityMovement(game);

            if (power)
            {
                // True power star mode, where the player receives different immunity properties
                Collision = new StarCollision();
            } else
            {
                // Star mode is being used purely for the blinking effect and temporary immunity
                Collision = mario.Collision;
            }
        }

        public void Left()
        {
            mario.Left();
        }

        public void Right()
        {
            mario.Right();
        }

        public void Up()
        {
            mario.Up();
        }

        public void Down()
        {
            mario.Down();
        }

        public void UpReleased()
        {
            mario.UpReleased();
        }

        public void DownReleased()
        {
            mario.DownReleased();
        }

        public void LeftReleased()
        {
            mario.LeftReleased();
        }

        public void RightReleased()
        {
            mario.RightReleased();
        }

        public void Use()
        {
            mario.Use();
        }

        public void Walk()
        {
            mario.Walk();
        }

        public void Run()
        {
            mario.Run();
        }

        public void ToBig()
        {
            if (State.Name != "Fire")
            {
                mario.ToBig();
            }
        }

        public void ToSmall()
        {
            mario.ToSmall();
        }

        public void ToFire()
        {
            mario.ToFire();
        }

        public void CauseDamage()
        {
            mario.CauseDamage();
        }

        public void Shoot()
        {
            mario.Shoot();
        }

        public new void Update(GameTime gameTime)
        {
            if (!Songs.Instance.starSongPlaying)
            {
                MediaPlayer.Pause();
                playPosition = MediaPlayer.PlayPosition;
                MediaPlayer.Stop();
                Songs.Instance.PlayStarSong();
            }
            
            duration -= gameTime.ElapsedGameTime.Milliseconds;
            if (duration <= 0)
            {
                MediaPlayer.Stop();
                Songs.Instance.PlaySong(playPosition);
                game.Mario = mario;
                mario.Collision = new PlayerCollision();
            }
            else
            {
                mario.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (duration % 200 < 100)
                mario.Draw(spriteBatch, location);
        }
    }
}
