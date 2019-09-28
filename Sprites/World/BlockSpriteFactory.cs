using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.World
{
    public class BlockSpriteFactory
    {
        public static BlockSpriteFactory Instance { get; } = new BlockSpriteFactory();

        private Texture2D brick;
        private Texture2D brickSmashing;
        private Texture2D brickIndestructable;
        private Texture2D groundBrickOverWorld;
        private Texture2D questionBlock;
        private Texture2D questionBlockHit;
        private Texture2D UGBrick;
        private Texture2D UGGroundBrick;
        private Texture2D GrayBrick;
        private Texture2D GrayfixBlock;
        private Texture2D step;

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            brick = content.Load<Texture2D>("Blocks\\Brick");
            brickSmashing = content.Load<Texture2D>("Blocks\\BrickSmashing");
            brickIndestructable = content.Load<Texture2D>("Blocks\\BrickIndestructable");
            groundBrickOverWorld = content.Load<Texture2D>("Blocks\\GroundBrickOverWorld");
            questionBlock = content.Load<Texture2D>("Blocks\\QuestionBlock");
            questionBlockHit = content.Load<Texture2D>("Blocks\\QuestionBlockHit");
            UGBrick = content.Load<Texture2D>("Blocks\\UGBrick");
            UGGroundBrick = content.Load<Texture2D>("Blocks\\UGgroundBrick");
            GrayBrick = content.Load<Texture2D>("Level 1-4\\grayBrick");
            GrayfixBlock = content.Load<Texture2D>("Level 1-4\\grayFixBlock");
            step = content.Load<Texture2D>("Level 1-4\\step");
        }

        public ISprite CreateBrickSprite()
        {
            return new StaticSprite(brick);
        }

        public ISprite CreateBrickSmashingSprite()
        {
            // return new StaticSprite(brickSmashing);
            return new ExplodingSprite(brickSmashing);
        }

        public ISprite CreateBrickIndestructableSprite()
        {
            return new StaticSprite(brickIndestructable);
        }

        public ISprite CreateGroundBrickOverWorldSprite()
        {
            return new StaticSprite(groundBrickOverWorld);
        }

        public ISprite CreateQuestionBlockSprite()
        {
            return new AnimatedSprite(questionBlock, 1, 4, 0.25);
        }

        public ISprite CreateQuestionBlockHitSprite()
        {
            return new StaticSprite(questionBlockHit);
        }

        public ISprite CreateUGBrickSprite()
        {
            return new StaticSprite(UGBrick);
        }

        public ISprite CreateUGGroundBrickSprite()
        {
            return new StaticSprite(UGGroundBrick);
        }

        public ISprite CreateGrayBrickSprite()
        {
            return new StaticSprite(GrayBrick);
        }

        public ISprite CreateGrayFixBlockSprite()
        {
            return new StaticSprite(GrayfixBlock);
        }

        internal ISprite CreateStepSprite()
        {
            return new StaticSprite(step);
        }
    }
}
