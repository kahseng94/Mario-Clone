using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Background;

namespace Sprint5.Entities.World
{
    class Flag : IEntity, IBackground
    {
        private ISprite flagSprite;

        private const int DOWN_INTERVAL = 20;
        private int downDuration = 0;

        public Flag(Vector2 position)
        {
            flagSprite = WorldElementSpriteFactory.Instance.CreateToadFlagSprite();
            Position = position;
        }

        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }

        public Vector2 Position
        {
            get; set;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            flagSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            if (downDuration > 0)
            {
                if (downDuration % DOWN_INTERVAL == 0 && Position.Y < 12)
                    Position = new Vector2(Position.X, Position.Y + 1);
                downDuration--;
            }
        }

        public void StartMovingDown(float targetY)
        {
            downDuration = (int)(DOWN_INTERVAL * (targetY - Position.Y));
        }
    }
}
