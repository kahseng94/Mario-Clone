using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Enemies
{
    public class KoopaSpriteFactory
    {
        public static KoopaSpriteFactory Instance { get; } = new KoopaSpriteFactory();

        private Texture2D koopa;
        private Texture2D koopaStomped;
        private Texture2D koopaUnstomping;
        private Texture2D koopaFlipped;
        private Texture2D koopaLeftMoving;
        private Texture2D koopaRightMoving;

        private KoopaSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            koopa = content.Load<Texture2D>("Enemies\\KoopaSprite");
            koopaStomped = content.Load<Texture2D>("Enemies\\KoopaStompedSprite");
            koopaUnstomping = content.Load<Texture2D>("Enemies\\KoopaUnstompingSprite");
            koopaFlipped = content.Load<Texture2D>("Enemies\\KoopaFlippedSprite");
            koopaLeftMoving = content.Load<Texture2D>("Enemies\\KoopaSprite");
            koopaRightMoving = content.Load<Texture2D>("Enemies\\KoopaRightSprite");

        }

        public ISprite CreateKoopaIdleSprite()
        {
            return new AnimatedSprite(koopa, 1, 2, 0.25);
        }

        public ISprite CreateKoopaStompedSprite()
        {
            return new StaticSprite(koopaStomped, 1, 2, koopaStomped.Width, koopaStomped.Height);
        }

        public ISprite CreateKoopaFlippedSprite()
        {
            return new StaticSprite(koopaFlipped, 1, 2, koopaFlipped.Width, koopaFlipped.Height);
        }

        public ISprite CreateKoopaUnstompingSprite()
        {
            return new AnimatedSprite(koopaUnstomping, 1, 2, 0.25);
        }

        public ISprite CreateKoopaLeftMovingSprite()
        {
            return new AnimatedSprite(koopaLeftMoving, 1, 2, 0.25, 0, -8f / 16f);
        }

        public ISprite CreateKoopaRightMovingSprite()
        {
            return new AnimatedSprite(koopaRightMoving, 1, 2, 0.25, 0, -8f / 16f);
        }
    }
}
