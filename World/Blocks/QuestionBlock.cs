using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Items;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Sounds;

namespace Sprint5.World.Blocks
{
    public class QuestionBlock : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return hit ? "QuestionBlockHit" : "QuestionBlock"; } }

        private ISprite sprite;
        private bool hit = false;
        private Game1 game;
        private IItem item;

        public QuestionBlock(Game1 game, IItem item)
        {
            this.game = game;
            this.item = item;
            Collision = new BlockCollision();
            sprite = BlockSpriteFactory.Instance.CreateQuestionBlockSprite();
        }

        public void Hit(IPlayer player)
        {
            SoundEffects.Instance.PlayBumpSound();
            if (!hit && null != item)
            {
                item.Position = new Vector2(Position.X, Position.Y - 1);
                sprite = BlockSpriteFactory.Instance.CreateQuestionBlockHitSprite();
                game.WorldLoader.Items.Add(item);
                if (!(item is Coin))
                {
                    SoundEffects.Instance.PlayPowerUpAppearsSound();
                }
                hit = true;
                sprite.Bump();
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
