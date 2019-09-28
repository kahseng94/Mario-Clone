using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Sounds;
using System.Threading;

namespace Sprint5.World.Blocks
{
    class UGBrick : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "Brick"; } }

        private Game1 game;
        private ISprite sprite;

        public UGBrick(Game1 game)
        {
            this.game = game;
            sprite = BlockSpriteFactory.Instance.CreateUGBrickSprite();
            Collision = new BlockCollision();
        }

        public void Hit(IPlayer player)
        {
            SoundEffects.Instance.PlayBumpSound();
            sprite.Bump();

            if (player.State.Name != "Small")
            {
                SoundEffects.Instance.PlayBreakBlockSound();
                sprite = BlockSpriteFactory.Instance.CreateBrickSmashingSprite();
                new Thread(() =>
                {
                    Thread.Sleep(300);
                    game.Map.SetBlock((int)Position.X, (int)Position.Y, null);
                }).Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
 