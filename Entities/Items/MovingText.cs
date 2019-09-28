using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Mario.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;

namespace Sprint5.Entities.Items
{
    class MovingText : MovingEntity, IItem
    {
        public override Rectangle Bounds { get; set; }
        public override ICollision Collision { get; set; }
        public string Type { get { return "MovingText"; } }
        public float XDirection { get; set; }

        private Game1 game;

        private string text;
        private Force buoyancy = new SimpleForce(2, 4);
        private int duration;

        public MovingText(Game1 game, string text, Vector2 position) : base(position, new LVector2(Limit<Vector2>.NONE), new LVector2(Limit<Vector2>.NONE))
        {
            this.game = game;
            this.text = text;
            Movement = new TextMovement();
            duration = 50;
        }

        public void AutoCosume(int v)
        {
            // NO-OP
        }

        public void Consume(IPlayer player)
        {
            // NO-OP
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (duration > 0)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(game.Content.Load<SpriteFont>("MarioFont"), text, location, Color.White);
                spriteBatch.End();
            }
        }

        public new void Update(GameTime gameTime)
        {
            if (duration > 0) --duration;

            ApplyForce(buoyancy);
            base.Update(gameTime);
        }
    }
}
