using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Background;
using Sprint5.Entities.Items;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;

namespace Sprint5.Entities.World
{
    class FlagPole : IEntity, IItem
    {
        public Vector2 Position { get; set; }

        private ISprite flagPoleSprite;
        private Game1 game;
        public FlagPole(Game1 game)
        {
            this.game = game;
            flagPoleSprite = WorldElementSpriteFactory.Instance.CreateToadFlagPoleSprite();
        }
        public Rectangle Bounds { get; set; }

        public ICollision Collision { get; set; }

        public string Type
        {
            get
            {
                return "FlagPole";
            }
        }

        public float XDirection
        {
            get; set;
        }

        public IMovement Movement
        {
            get; set;
        }

        public LVector2 Velocity
        {
            get { return new LVector2(0, 0, new Physics.Vectors.Limits.Limit<Vector2>()); }
            set { }
        }

        public LVector2 Acceleration
        {
            get
            {
                return this.Velocity;
            }

            set
            {
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            flagPoleSprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            flagPoleSprite.Update(gameTime);
        }

        private bool hit = false;

        public void Consume(IPlayer player)
        {
            if (hit) return;
            hit = true;

            Flag flag = null;
            foreach (IBackground it in game.WorldLoader.Background)
            {
                if (it is Flag)
                {
                    flag = (Flag)it;
                    flag.StartMovingDown(game.Mario.Position.Y);
                    break;
                }
            }

            game.Mario = new MarioFinish((Mario.Mario)game.Mario, game, flag);

        }

        public void AutoCosume(int v)
        {
        }

        public void ApplyForce(Force force)
        {
        }
    }
}
