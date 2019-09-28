using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.World.Sounds;
using Sprint5.World.Blocks;

namespace Sprint5.Entities.Items
{
    public class Hammer : MovingEntity, IItem
    {
        public string Type { get { return "Hammer"; } }

        public float XDirection { get; set; }

        public override sealed Rectangle Bounds { get; set; }

        public override sealed ICollision Collision { get; set; }

        private ISprite hammerSprite;
        private bool consumed = false;
        private int autoConsume = 0;
        private Game1 game;

        public Hammer(Game1 game, Vector2 position) :
            base(position, new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new ItemCollision();
            hammerSprite = ItemSpriteFactory.Instance.CreateHammerSprite();
        }

        public void AutoCosume(int v)
        {
            autoConsume = v;
        }

        public void Consume(IPlayer player)
        {
            if (!consumed)
            {
                SoundEffects.Instance.PlayCoinSound();
                consumed = true;

                // finish mario
                for (int i = 0; i < game.Map.Height; ++i)
                    for (int j = 0; j < game.Map.Width; ++j)
                    {
                        if (game.Map.GetBlock(j, i) is Princess)
                        {
                            Princess princess = (Princess)game.Map.GetBlock(j, i);
                            game.Mario = new MarioFinishCastle(game, princess);
                        }
                    }
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (autoConsume > 0)
            {
                --autoConsume;
                if (autoConsume == 0) Consume(game.Mario);
            }
            if (!consumed)
            {
                base.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!consumed)
            {
                hammerSprite.Draw(spriteBatch, location);
            }
        }
    }
}
