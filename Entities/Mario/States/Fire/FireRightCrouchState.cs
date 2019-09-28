using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class FireRightCrouchState : IMarioState
    {
        public string Name { get { return "Fire"; } }

        private Mario mario;
        private ISprite sprite;

        public FireRightCrouchState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateFireRightCrouchSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
            mario.Walk();
        }

        public void Up()
        {
            mario.State = new FireRightIdleState(mario);
        }

        public void Down()
        {
            mario.State = new FireRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new FireLeftCrouchState(mario);
        }

        public void Right()
        {
            if (!mario.Movement.IsOnGround(mario))
            {
                // Apply right force
                mario.ApplyForce(Mario.AirRight);
            }
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
            mario.State = new FireRightIdleState(mario);
        }

        public void UpReleased()
        {
        }

        public void Use()
        {
            mario.Shoot();
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void CauseDamage()
        {
            //mario.State = new FireDeadState(mario);
            ToBig();
        }

        public void ToBig()
        {
            mario.State = new BigRightCrouchState(mario);
        }

        public void ToSmall()
        {
            SoundEffects.Instance.PlayPipeSound();
            mario.State = new SmallRightIdleState(mario);
        }

        public void ToFire()
        {
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
