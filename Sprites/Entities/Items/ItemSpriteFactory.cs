using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.Entities.Items
{
    public class ItemSpriteFactory
    {
        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private Texture2D coinFloating;
        private Texture2D coinFromBlock;
        private Texture2D fireFlower;
        private Texture2D mushroom;
        private Texture2D mushroomOneUp;
        private Texture2D star;
        private Texture2D hammer;
        private Texture2D princess;

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            coinFloating = content.Load<Texture2D>("Items\\Coin");
            coinFromBlock = content.Load<Texture2D>("Items\\CoinFromBlock");
            fireFlower = content.Load<Texture2D>("Items\\FireFlower");
            mushroom = content.Load<Texture2D>("Items\\Mushroom");
            mushroomOneUp = content.Load<Texture2D>("Items\\MushroomOneUp");
            star = content.Load<Texture2D>("Items\\Star");
            hammer = content.Load<Texture2D>("Level 1-4\\hammer");
            princess = content.Load<Texture2D>("Level 1-4\\Princess");
        }

        public ISprite CreateCoinFloatingSprite ()
        {
            return new AnimatedSprite(coinFloating, 1, 4, 0.25);
        }

        public ISprite CreateCoinFromBlockSprite()
        {
            return new AnimatedSprite(coinFromBlock, 1, 4, 0.25);
        }

        public ISprite CreateFireFlowerSprite()
        {
            return new AnimatedSprite(fireFlower, 1, 4, 0.25);
        }

        public ISprite CreateMushroomSprite()
        {
            return new StaticSprite(mushroom);
        }

        public ISprite CreateMushroomOneUpSprite()
        {
            return new StaticSprite(mushroomOneUp);
        }

        public ISprite CreateStarSprite()
        {
            return new AnimatedSprite(star, 1, 4, 0.25);
        }

        internal ISprite CreateHammerSprite()
        {
            return new StaticSprite(hammer);
        }

        internal ISprite CreatePrincessSprite()
        {
            return new StaticSprite(princess);
        }
    }
}
