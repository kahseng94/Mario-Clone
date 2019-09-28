using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class BigRightRunState : IMarioState
    {
        public string Name { get { return "Big"; } }

        private Mario mario;
        private ISprite sprite;

        public BigRightRunState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateBigRightRunSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new BigRightJumpState(mario);
        }

        public void Down()
        {
            mario.State = new BigRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BigLeftIdleState(mario);
        }

        public void Right()
        {
            // Apply right force
            mario.ApplyForce(mario.Movement.IsOnGround(mario) ? Mario.GroundRight : Mario.AirRight);
        }

        public void RightReleased()
        {
            mario.State = new BigRightIdleState(mario);
        }

        public void LeftReleased()
        {
        }

        public void DownReleased()
        {
        }

        public void UpReleased()
        {
        }

        public void Use()
        {
            mario.Run();
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
        }

        public void ToSmall()
        {
            SoundEffects.Instance.PlayPipeSound();
            mario.State = new SmallRightRunState(mario);
        }

        public void ToFire()
        {
            mario.State = new FireRightRunState(mario);
        }

        public void CauseDamage()
        {
            //mario.State = new BigDeadState(mario);
            ToSmall();
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
