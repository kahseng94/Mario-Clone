using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Items;
using Sprint5.Entities.Mario;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Sounds;

namespace Sprint5.World.Blocks
{
    public class MultiCoinBlock : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "MultiCoinBlock"; } }

        private ISprite sprite;
        private int count;
        private Game1 game;
        private IItem item;

        public MultiCoinBlock(Game1 game, IItem item)
        {
            this.game = game;
            this.item = item;
            Collision = new BlockCollision();
            sprite = BlockSpriteFactory.Instance.CreateBrickSprite();
        }

        public void Hit(IPlayer player)
        {
            SoundEffects.Instance.PlayBumpSound();
            if (count < 10)
            {
                item = new Coin(game, new Vector2(Position.X, Position.Y - 1));
                item.AutoCosume(50);
                item.Velocity = new LVector2(Coin.popVelocity.Vector, Limit<Vector2>.NONE);
                item.Position = new Vector2(Position.X, Position.Y - 1);
                game.WorldLoader.Items.Add(item);
                count++;
                sprite.Bump();
            }
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (count == 10)
            {
                sprite = BlockSpriteFactory.Instance.CreateQuestionBlockHitSprite();
                sprite.Draw(spriteBatch, location);
            }
            else
            {
                sprite.Draw(spriteBatch, location);

            }

        }
    }
}
