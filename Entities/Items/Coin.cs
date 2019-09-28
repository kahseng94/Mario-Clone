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

namespace Sprint5.Entities.Items
{
    public class Coin : MovingEntity, IItem
    {
        public string Type { get { return "Coin"; } }

        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }

        public float XDirection { get; set; }

        private ISprite coinSprite;
        private bool consumed = false;
        private int autoConsume = 0;
        private Game1 game;

        public static readonly LVector2 popVelocity = new LVector2(0, 3, Limit<Vector2>.NONE);

        public Coin(Game1 game, Vector2 position) :
            base(position, new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new ItemCollision();
            coinSprite = ItemSpriteFactory.Instance.CreateCoinFloatingSprite();
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
                
                game.HUD.GetCoin();
                MovingText score = new MovingText(game, "200", Position);
                game.WorldLoader.MovingTexts.Add(score);
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
                coinSprite.Draw(spriteBatch, location);
            }
        }
    }
}
