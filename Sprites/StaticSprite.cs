using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint5.World;

namespace Sprint5.Sprites
{
    public class StaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Width { get; }
        public int Height { get; }
        public float Scale { get { return 2; } }

        private float xOffset = 0;
        private float yOffset = 0;

        private Rectangle sourceRectangle;
        private Rectangle destRectangle = new Rectangle();
        private int bumpTimer;

        public StaticSprite(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            sourceRectangle = rectangle;
        }

        public StaticSprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            Width = width;
            Height = height;
            sourceRectangle = new Rectangle(x, y, width, height);
        }

        public StaticSprite(Texture2D texture, int x, int y, int width, int height, float xOffset, float yOffset)
        {
            Texture = texture;
            Width = width;
            Height = height;
            sourceRectangle = new Rectangle(x, y, width, height);

            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        public StaticSprite(Texture2D texture)
        {
            Texture = texture;
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (bumpTimer == 1) yOffset = 0;
            --bumpTimer;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destRectangle.X = (int)((location.X + xOffset) * Scale * Level.unitSize);
            destRectangle.Y = (int)((location.Y + yOffset) * Scale * Level.unitSize);
            destRectangle.Width = (int)(sourceRectangle.Width * Scale);
            destRectangle.Height = (int)(sourceRectangle.Height * Scale);

            spriteBatch.Begin(transformMatrix: Game1.Camera.TranslationMatrix);
            spriteBatch.Draw(Texture, destRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public virtual void DrawAtFixedPosition(SpriteBatch spriteBatch, Vector2 location)
        {
            destRectangle.X = (int)((location.X + xOffset) * Scale * Level.unitSize);
            destRectangle.Y = (int)((location.Y + yOffset) * Scale * Level.unitSize);
            destRectangle.Width = (int)(sourceRectangle.Width * Scale);
            destRectangle.Height = (int)(sourceRectangle.Height * Scale);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Bump()
        {
            yOffset = -0.1f;
            bumpTimer = 10;
        }
    }
}
