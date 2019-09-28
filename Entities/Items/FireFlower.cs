using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Physics.Forces;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Items
{
    public class FireFlower : MovingEntity, IItem
    {
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }
        public string Type { get { return "FireFlower"; } }
        public float XDirection { get; set; } = 1;

        private ISprite fireFlowerSprite;
        private bool consumed = false;

        private Game1 game;

        public FireFlower(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(new RectangleLimit(5, 10)), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new ItemCollision();
            fireFlowerSprite = ItemSpriteFactory.Instance.CreateFireFlowerSprite();
        }

        public void Consume(IPlayer player)
        {
            if (!consumed)
            {
                SoundEffects.Instance.PlayPowerUpSound();
                player.ToFire();
                consumed = true;

                game.HUD.GetScore(1000);
                MovingText score = new MovingText(game, "1000", Position);
                game.WorldLoader.MovingTexts.Add(score);
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (!consumed)
            {
                ApplyForce(SimpleForce.gravity);

                base.Update(gameTime);

                fireFlowerSprite.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!consumed)
            {
                fireFlowerSprite.Draw(spriteBatch, location);
            }
        }

        public void AutoCosume(int v)
        {
        }
    }
}
