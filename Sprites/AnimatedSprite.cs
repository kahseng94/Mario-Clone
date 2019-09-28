using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint5.World;

namespace Sprint5.Sprites
{
    public class AnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Height { get { return Texture.Height / rows; } }
        public int Width { get { return Texture.Width / columns; } }
        public float Scale { get { return 2; } }

        private int rows;
        private int columns;
        private double frameTime;
        private double startTime = -1;
        private int currentFrame;
        private int totalFrames;

        private int bumpTimer = 0;

        private float xOffset = 0;
        private float yOffset = 0;

        private Rectangle sourceRectangle = new Rectangle();
        private Rectangle destRectangle = new Rectangle();

        public AnimatedSprite(Texture2D texture, int rows, int columns, double frameTime)
        {
            Texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.frameTime = frameTime;
            currentFrame = 0;
            totalFrames = rows * columns;

            sourceRectangle = new Rectangle(0, 0, Texture.Width / columns, Texture.Height / rows);
        }

        public AnimatedSprite(Texture2D texture, int rows, int columns, double frameTime, float xOffset, float yOffset)
        {
            Texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.frameTime = frameTime;
            currentFrame = 0;
            totalFrames = rows * columns;

            sourceRectangle = new Rectangle(0, 0, Texture.Width / columns, Texture.Height / rows);

            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (bumpTimer == 1) yOffset = 0;
            --bumpTimer;

            double time = gameTime.TotalGameTime.TotalSeconds;

            if (startTime < 0)
            {
                startTime = time;
            }

            currentFrame = (int)((time - startTime) / frameTime) % totalFrames;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // Update source rectangle
            sourceRectangle.X = sourceRectangle.Width * (currentFrame % columns);
            sourceRectangle.Y = sourceRectangle.Height * (int)((float)currentFrame / columns);

            // Update destination rectangle
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
            // Update source rectangle
            sourceRectangle.X = sourceRectangle.Width * (currentFrame % columns);
            sourceRectangle.Y = sourceRectangle.Height * (int)((float)currentFrame / columns);

            // Update destination rectangle
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
