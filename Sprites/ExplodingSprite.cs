using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint5.World;

namespace Sprint5.Sprites
{
    public class ExplodingSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Width { get; }
        public int Height { get; }
        public float Scale { get { return 2; } }

        private float xOffset = 0;
        private float yOffset = 0;

        private Vector2 rotationOrigin = new Vector2(4f, 4f);
        private Rectangle sourceRectangle;
        private Rectangle destRectangle = new Rectangle();

        private float explosion = 0;
        private float spin = 10;
        private float speed = 100;

        private Rectangle srcTopLeft;
        private Rectangle srcTopRight;
        private Rectangle srcBottomLeft;
        private Rectangle srcBottomRight;

        private Rectangle destTopLeft = new Rectangle();
        private Rectangle destTopRight = new Rectangle();
        private Rectangle destBottomLeft = new Rectangle();
        private Rectangle destBottomRight = new Rectangle();
        

        public ExplodingSprite(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            sourceRectangle = rectangle;
            SplitSourceRectangle();
        }

        public ExplodingSprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            Width = width;
            Height = height;
            sourceRectangle = new Rectangle(x, y, width, height);
            SplitSourceRectangle();
        }

        public ExplodingSprite(Texture2D texture, int x, int y, int width, int height, float xOffset, float yOffset)
        {
            Texture = texture;
            Width = width;
            Height = height;
            sourceRectangle = new Rectangle(x, y, width, height);
            SplitSourceRectangle();

            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        public ExplodingSprite(Texture2D texture)
        {
            Texture = texture;
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            SplitSourceRectangle();
        }

        public virtual void Update(GameTime gameTime)
        {
            explosion += gameTime.ElapsedGameTime.Milliseconds / 1000f;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destRectangle.X = (int)((location.X + xOffset) * Scale * Level.unitSize);
            destRectangle.Y = (int)((location.Y + yOffset) * Scale * Level.unitSize);
            destRectangle.Width = (int)(sourceRectangle.Width * Scale);
            destRectangle.Height = (int)(sourceRectangle.Height * Scale);

            spriteBatch.Begin(transformMatrix: Game1.Camera.TranslationMatrix);

            float rotation = explosion * spin;
            spriteBatch.Draw(Texture, ExplodeCorner(destTopLeft, -speed, -speed), srcTopLeft, Color.White, -rotation, rotationOrigin, SpriteEffects.None, 0);
            spriteBatch.Draw(Texture, ExplodeCorner(destTopRight, speed, -speed), srcTopRight, Color.White, rotation, rotationOrigin, SpriteEffects.None, 0);
            spriteBatch.Draw(Texture, ExplodeCorner(destBottomLeft, -speed, speed), srcBottomLeft, Color.White, -rotation, rotationOrigin, SpriteEffects.None, 0);
            spriteBatch.Draw(Texture, ExplodeCorner(destBottomRight, speed, speed), srcBottomRight, Color.White, rotation, rotationOrigin, SpriteEffects.None, 0);
            
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

        private Rectangle ExplodeCorner(Rectangle rectangle, float x, float y)
        {
            rectangle.X = destRectangle.X + Level.unitSize + (int) (explosion * x);
            rectangle.Y = destRectangle.Y + Level.unitSize + (int) (explosion * y);
            rectangle.Width = (int) (destRectangle.Width * 0.5f);
            rectangle.Height = (int) (destRectangle.Height * 0.5f);
            return rectangle;
        }

        private void SplitSourceRectangle()
        {
            int x = sourceRectangle.X;
            int y = sourceRectangle.Y;
            int width = sourceRectangle.Width / 2;
            int height = sourceRectangle.Height / 2;

            srcTopLeft = new Rectangle(x, y, width, height);
            srcTopRight = new Rectangle(x + width, y, width, height);
            srcBottomLeft = new Rectangle(x, y + height, width, height);
            srcBottomRight = new Rectangle(x + width, y + height, width, height);
        }

        public void Bump()
        {
        }
    }
}
