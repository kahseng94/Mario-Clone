using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Projectile
{
    public class FireballSpriteFactory
    {
        public static FireballSpriteFactory Instance { get; } = new FireballSpriteFactory();

        private Texture2D fireball, bowserFire;

        public FireballSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            fireball = content.Load<Texture2D>("Projectiles\\FireballMario");
            bowserFire = content.Load<Texture2D>("Level 1-4\\fire");
        }

        public ISprite CreateFireballSprite()
        {
            return new AnimatedSprite(fireball, 2, 2, 0.25);
        }

        public ISprite CreateBowserFireSprite()
        {
            return new StaticSprite(bowserFire);
        }
    }
}
