using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;

namespace Sprint5.Entities.Items
{
    public class TextItem : IItem
    {
        public Vector2 Position { get; set; }

        private string _text;
        internal static Game1 game;

        public TextItem(string text, Vector2 position)
        {
            _text = text;
            Position = position;
        }

        public string Type
        {
            get
            {
                return "Text";
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
            get; set;
        }

        public LVector2 Acceleration
        {
            get; set;
        }

        public Rectangle Bounds
        {
            get; set;
        }

        public ICollision Collision
        {
            get; set;
        }

        public void Consume(IPlayer player)
        {
        }

        public void AutoCosume(int v)
        {
        }

        public void ApplyForce(Force force)
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(game.Content.Load<SpriteFont>("MarioFont"), _text, location, Color.White);
            spriteBatch.End();
        }
    }
}