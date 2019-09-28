using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Mario
{
    public class MarioSpriteFactory
    {
        public static MarioSpriteFactory Instance { get; } = new MarioSpriteFactory();

        private Texture2D mario;

        private MarioSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            mario = content.Load<Texture2D>("mario1");
        }

        // Mario Small Sprites

        public ISprite CreateSmallLeftIdleSprite()
        {
            return new StaticSprite(mario, 179, 0, 17, 16);
        }

        public ISprite CreateSmallRightIdleSprite()
        {
            return new StaticSprite(mario, 209, 0, 17, 16);
        }

        public ISprite CreateSmallLeftRunSprite()
        {
            return new MarioStaticSprite(mario, 89, 0, 17, 16, 30);
        }

        public ISprite CreateSmallRightRunSprite()
        {
            return new MarioStaticSprite(mario, 300, 0, 17, 16, -30);
        }

        public ISprite CreateSmallLeftRunStopSprite()
        {
            return new StaticSprite(mario, 329, 0, 17, 16);
        }

        public ISprite CreateSmallRightRunStopSprite()
        {
            return new StaticSprite(mario, 59, 0, 17, 16);
        }

        public ISprite CreateSmallLeftJumpSprite()
        {
            return new StaticSprite(mario, 29, 0, 17, 16);
        }

        public ISprite CreateSmallRightJumpSprite()
        {
            return new StaticSprite(mario, 359, 0, 17, 16);
        }

        public ISprite CreateSmallDeadSprite()
        {
            return new StaticSprite(mario, 0, 16, 16, 15);
        }

        // Mario Big Sprites

        public ISprite CreateBigLeftIdleSprite()
        {
            return new StaticSprite(mario, 180, 52, 18, 35, 0, -1);
        }

        public ISprite CreateBigRightIdleSprite()
        {
            return new StaticSprite(mario, 210, 52, 18, 35, 0, -1);
        }

        public ISprite CreateBigLeftRunSprite()
        {
            return new MarioStaticSprite(mario, 90, 52, 18, 34, 30, 0, -1);
        }

        public ISprite CreateBigRightRunSprite()
        {
            return new MarioStaticSprite(mario, 300, 52, 18, 34, -30, 0, -1);
        }

        public ISprite CreateBigLeftJumpSprite()
        {
            return new StaticSprite(mario, 28, 52, 18, 34, 0, -1);
        }

        public ISprite CreateBigRightJumpSprite()
        {
            return new StaticSprite(mario, 360, 52, 18, 34, 0, -1);
        }

        public ISprite CreateBigLeftCrouchSprite()
        {
            return new StaticSprite(mario, 0, 58, 18, 22, 0, -5f / 16f);
        }

        public ISprite CreateBigRightCrouchSprite()
        {
            return new StaticSprite(mario, 388, 58, 18, 22, -2f / 16f, -5f / 16f);
        }

        // Mario Fire Sprites

        public ISprite CreateFireLeftIdleSprite()
        {
            return new StaticSprite(mario, 180, 122, 25, 35, 0, -1);
        }

        public ISprite CreateFireRightIdleSprite()
        {
            return new StaticSprite(mario, 209, 122, 25, 35, 0, -1);
        }

        public ISprite CreateFireLeftWalkSprite()
        {
            return new MarioStaticSprite(mario, 102, 122, 25, 35, 25, 0, -1);
        }

        public ISprite CreateFireRightWalkSprite()
        {
            return new MarioStaticSprite(mario, 287, 122, 25, 35, -25, 0, -1);
        }

        public ISprite CreateFireLeftWalkStopSprite()
        {
            return new StaticSprite(mario, 50, 120, 25, 35, 0, -1);
        }

        public ISprite CreateFireRightWalkStopSprite()
        {
            return new StaticSprite(mario, 330, 120, 25, 35, 0, -1);
        }

        public ISprite CreateFireLeftJumpSprite()
        {
            return new StaticSprite(mario, 27, 122, 25, 35, 0, -1);
        }

        public ISprite CreateFireRightJumpSprite()
        {
            return new StaticSprite(mario, 355, 122, 25, 35, -8f / 16f, -1);
        }

        public ISprite CreateFireLeftCrouchSprite()
        {
            return new StaticSprite(mario, 0, 117, 25, 35, 0, -1);
        }

        public ISprite CreateFireRightCrouchSprite()
        {
            return new StaticSprite(mario, 380, 117, 25, 35, -9f / 16f, -1);
        }

        public ISprite CreateFireOnFlagSprite()
        {
            return new StaticSprite(mario, 359, 158, 18, 34);
        }

        public ISprite CreateSmallOnFlagSprite()
        {
            return new StaticSprite(mario, 330, 30, 17, 16);
        }

        public ISprite CreateBigOnFlagSprite()
        {
            return new StaticSprite(mario, 359, 88, 18, 34);
        }
    }
}
