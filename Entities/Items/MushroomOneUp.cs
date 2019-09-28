using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;
using System;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Physics.Forces;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Items
{
    public class MushroomOneUp : MovingEntity, IItem
    {
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }
        public string Type { get { return "MushroomOneUp"; } }
        public float XDirection { get; set; } = 1;

        private ISprite mushroomOneUpSprite;
        private bool consumed = false;

        public MushroomOneUp(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(new RectangleLimit(5, 10)), new LVector2(Limit<Vector2>.NONE))
        {
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new ItemCollision();
            mushroomOneUpSprite = ItemSpriteFactory.Instance.CreateMushroomOneUpSprite();

        }

        public void Consume(IPlayer player)
        {
            if (!consumed)
            {
                // One up player
                SoundEffects.Instance.PlayOneUpSound();
                consumed = true;

                Game1.Lives++;
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (!consumed)
            {
                ApplyForce(new SimpleForce(XDirection, 0));
                ApplyForce(SimpleForce.gravity);

                base.Update(gameTime);

                mushroomOneUpSprite.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!consumed)
            {
                mushroomOneUpSprite.Draw(spriteBatch, location);
            }
        }

        public void AutoCosume(int v)
        {
            throw new NotImplementedException();
        }
    }
}
