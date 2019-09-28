using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.World;

namespace Sprint5.Sprites.Entities.Mario
{
    public class MarioStaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Width { get; }
        public int Height { get; }
        public float Scale { get { return 2; } }

        private float xOffset = 0;
        private float yOffset = 0;

        private Rectangle sourceRectangle;
        private Rectangle destRectangle = new Rectangle();

        private int speed = 8;
        private int counter = 0;
        private int current = 0;
        private int x;
        private int offset;

        public MarioStaticSprite(Texture2D texture, int x, int y, int width, int height, int offset)
        {
            Texture = texture;
            sourceRectangle = new Rectangle(x, y, width, height);

            Width = width;
            Height = height;

            this.x = x;
            this.offset = offset;
        }

        public MarioStaticSprite(Texture2D texture, int x, int y, int width, int height, int offset, float xOffset, float yOffset)
        {
            Texture = texture;
            sourceRectangle = new Rectangle(x, y, width, height);

            Width = width;
            Height = height;

            this.x = x;
            this.offset = offset;

            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        public void Update(GameTime gameTime)
        {
            counter++;
            if (counter % speed == 0)
            {
                current++;
                if (current == 3)
                {
                    current = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle.X = x + offset * current;

            destRectangle.X = (int)((location.X + xOffset) * Scale * Level.unitSize);
            destRectangle.Y = (int)((location.Y + yOffset) * Scale * Level.unitSize);
            destRectangle.Width = (int)(sourceRectangle.Width * Scale);
            destRectangle.Height = (int)(sourceRectangle.Height * Scale);

            spriteBatch.Begin(transformMatrix: Game1.Camera.TranslationMatrix); ;
            spriteBatch.Draw(Texture, destRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public virtual void DrawAtFixedPosition(SpriteBatch spriteBatch, Vector2 location)
        {
        }

        public void Bump()
        {
        }
    }
}
