using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.World.Blocks;
using Sprint5.World.Pipes;

namespace Sprint5.World
{
    public class Level
    {
        public static readonly int unitSize = 16;
        public static readonly Rectangle unitbounds = new Rectangle(0, 0, 1, 1);

        public int Width { get; }
        public int Height { get; }
        private IBlock[][] Blocks;

        public Level(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;

            Blocks = new IBlock[Width][];
            for (int x = 0; x < Width; x++)
            {
                Blocks[x] = new IBlock[Height];
            }
        }

        public bool IsBlock(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return true;
            }

            return Blocks[x][y] != null;
        }

        public bool ContainsBlock(int xMin, int xMax, int yMin, int yMax)
        {
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    if (IsBlock(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IBlock GetBlock(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return null;
            }

            return Blocks[x][y];
        }

        public void SetBlock(int x, int y, IBlock block)
        {
            Blocks[x][y] = block;
            if (block != null)
            {
                block.Position = new Vector2(x, y);
                block.Bounds = unitbounds;
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Blocks[x][y] != null)
                    {
                        Blocks[x][y].Update(gameTime);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    IBlock block = Blocks[x][y];
                    if (block != null)
                    {
                        block.Draw(spriteBatch, block.Position);
                    }
                }
            }
        }

        public void SetHiddenBlock(int x, int y, IBlock block)
        {
            Blocks[x][y] = block;
        }
    }
}
