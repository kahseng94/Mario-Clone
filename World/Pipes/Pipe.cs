using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Collision;
using Sprint5.Sprites;
using Sprint5.Sprites.World;
using Sprint5.World.Blocks;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Items;
using Sprint5.Entities.Movement;

namespace Sprint5.World.Pipes
{
    public class Pipe : IBlock
    {
        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public string Type { get { return "Pipe"; } }

        public string Part { get; protected set; }

        public ICollision Collision { get; set; }
        public Side Side
        {
            get
            {
                if (Part == "UGTop")
                    return Side.TOP;
                else if (Part == "SWEntrance")
                    return Side.LEFT;
                else
                    return Side.BOTTOM; // it is impossible to hit a pipe body block from bottom
            }
        }

        private ISprite pipeSprite;
        private Game1 game;

        public Pipe(string part, Game1 game)
        {
            Part = part;
            this.game = game;
            if (part.Equals("UGTop") || part.Equals("Top"))
            {
                Collision = new BlockCollision();
                pipeSprite = WorldElementSpriteFactory.Instance.CreatePipeTopSprite();
            }
            else if (part.Equals("Body"))
            {
                Collision = new BlockCollision();
                pipeSprite = WorldElementSpriteFactory.Instance.CreatePipeTopBodySprite();
            }
            else if (part.Equals("SWEntrance"))
            {
                Bounds = new Rectangle(0, 0, 1, 2);
                Collision = new BlockCollision();
                pipeSprite = WorldElementSpriteFactory.Instance.CreateSWPipeEntranceSprite();
            }
            else if (part.Equals("SWBody"))
            {
                Collision = new BlockCollision();
                pipeSprite = WorldElementSpriteFactory.Instance.CreateSWPipeBodySprite();
            }
        }

        public void Update(GameTime gameTime)
        {
            pipeSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            pipeSprite.Draw(spriteBatch, location);
        }

        public void Hit(IPlayer player)
        {
        }

        public void Enter()
        {
            if (game.LevelName.StartsWith("UG"))
                game.SavedWorld.LoadSavedWorld(game);
            else
            {
                if (Side == Side.LEFT)
                    game.Mario.Position += new Vector2(3, 0);
                game.SavedWorld.SaveCurrentWorld(game);
                IPlayer m = game.Mario;
                game.WorldLoader.LoadWorld("UGLevel", game);
                game.BackgroundColor = Color.Black;
                Vector2 newPosition = game.Mario.Position;
                game.Mario = m;
                game.Mario.Position = newPosition;
            }
        }
    }
}

