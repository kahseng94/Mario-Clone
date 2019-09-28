using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class SmallRightJumpState : IMarioState
    {
        public string Name { get { return "Small"; } }

        private Mario mario;
        private ISprite sprite;

        public SmallRightJumpState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateSmallRightJumpSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
        }

        public void Left()
        {
            mario.State = new SmallLeftIdleState(mario);
        }

        public void Right()
        {
            // Apply right force
            mario.ApplyForce(mario.Movement.IsOnGround(mario) ? Mario.GroundRight : Mario.AirRight);
        }

        public void Up()
        {
            // Apply jump force
            if (mario.Movement.IsOnGround(mario))
            {
                SoundEffects.Instance.PlayJumpSmallSound();
                mario.ApplyForce(Mario.Jump);
            }
        }

        public void Down()
        {
            mario.State = new SmallRightIdleState(mario);
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
        }

        public void UpReleased()
        {
            mario.State = new SmallRightIdleState(mario);
        }

        public void Use()
        {
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
            mario.State = new BigRightJumpState(mario);
        }

        public void ToSmall()
        {
        }

        public void ToFire()
        {
            mario.State = new FireRightJumpState(mario);
        }

        public void CauseDamage()
        {
            SoundEffects.Instance.PlayMarioDieSound();
            mario.State = new SmallDeadState(mario);
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
