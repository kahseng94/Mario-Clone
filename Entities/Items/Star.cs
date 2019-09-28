using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;
using Sprint5.Physics.Vectors;
using System;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.Physics.Forces;
using Sprint5.World.Sounds;
using Microsoft.Xna.Framework.Media;

namespace Sprint5.Entities.Items
{
    public class Star : MovingEntity, IItem
    {
        public override sealed Rectangle Bounds { get; set; }
        public override sealed ICollision Collision { get; set; }
        public string Type { get { return "Star"; } }
        public float XDirection { get; set; } = 1;

        private Game1 game;
        private ISprite starSprite;
        private bool consumed = false;
        private Force bounce = new Impulse(0, 1);

        public Star(Game1 game, float x, float y) : base(new Vector2(x, y), new LVector2(new RectangleLimit(5, 10)), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            Bounds = new Rectangle(0, 0, 1, 1);
            Movement = new EntityMovement(game);
            Collision = new ItemCollision();
            starSprite = ItemSpriteFactory.Instance.CreateStarSprite();
        }

        public void Consume(IPlayer player)
        {
            if (!consumed)
            {
                // Set player to star mode
                SoundEffects.Instance.PlayPowerUpSound();
                game.Mario = new MarioStar(game, game.Mario, 10000, true);
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
                ApplyForce(new SimpleForce(XDirection, 0));
                ApplyForce(SimpleForce.gravity);

                if (Movement.IsOnGround(this))
                {
                    ApplyForce(bounce);
                }

                base.Update(gameTime);

                starSprite.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (!consumed)
            {
                starSprite.Draw(spriteBatch, location);
            }
        }

        public void AutoCosume(int v)
        {
            throw new NotImplementedException();
        }
    }
}
