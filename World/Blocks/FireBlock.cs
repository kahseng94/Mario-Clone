using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Projectiles;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using System;

namespace Sprint5.World.Blocks
{
    public class FireBlock : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public ICollision Collision { get; set; }
        public string Type { get { return "FireBlock"; } }

        private ISprite sprite;
        private Game1 game;

        private int deg = 0;

        private Fireball[] fireballs = new Fireball[9];

        public FireBlock(Game1 game, int x, int y)
        {
            this.game = game;
            Collision = new BlockCollision();
            sprite = BlockSpriteFactory.Instance.CreateQuestionBlockHitSprite();

            Position = new Vector2(x, y);

            for (int i = 0; i < fireballs.Length; ++i)
            {
                fireballs[i] = new Fireball(game,
                    new Vector2(Position.X + 0.25f - (float)i / 4, Position.Y + 0.25f), 0)
                { DisableGravity = true };
                game.WorldLoader.Fireballs.Add(fireballs[i]);
            }
        }

        public void Hit(IPlayer player)
        {
        }

        public void Update(GameTime gameTime)
        {
            deg = (deg + 1) % 360;
            for (int i = 0; i < fireballs.Length; ++i)
            {
                fireballs[i].Update(gameTime);
                fireballs[i].Position = new Vector2(
                    Position.X + 0.25f - (float)(i * Math.Cos(deg * Math.PI / 180) * 1.414f / 4),
                    Position.Y + 0.25f - (float)(i * Math.Sin(deg * Math.PI / 180) * 1.414f / 4));
                if (fireballs[i].Position.X >= game.Mario.Position.X - 0.5f && fireballs[i].Position.X <= game.Mario.Position.X + 0.5f &&
                    fireballs[i].Position.Y >= game.Mario.Position.Y - 0.5f && fireballs[i].Position.Y <= game.Mario.Position.Y + 0.5f)
                {
                    game.Mario.CauseDamage();
                }
            }

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
            //foreach (var fb in fireballs)
            //    fb.Draw(spriteBatch, fb.Position);
        }
    }
}
