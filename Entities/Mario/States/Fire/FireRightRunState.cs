using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class FireRightRunState : IMarioState
    {
        public string Name { get { return "Fire"; } }

        private Mario mario;
        private ISprite sprite;

        public FireRightRunState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateFireRightWalkSprite();

            mario.Bounds = new Rectangle(0, -1, 1, 2);
            mario.Walk();
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new FireRightJumpState(mario);
        }

        public void Down()
        {
            mario.State = new FireRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new FireLeftIdleState(mario);
        }

        public void Right()
        {
            // Apply right force
            mario.ApplyForce(mario.Movement.IsOnGround(mario) ? Mario.GroundRight : Mario.AirRight);
        }

        public void RightReleased()
        {
            mario.State = new FireRightIdleState(mario);
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
            mario.Shoot();
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
            mario.State = new BigRightRunState(mario);
        }

        public void ToSmall()
        {
            SoundEffects.Instance.PlayPipeSound();
            mario.State = new SmallRightRunState(mario);
        }

        public void ToFire()
        {
        }

        public void CauseDamage()
        {
            //mario.State = new FireDeadState(mario);
            ToBig();
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
