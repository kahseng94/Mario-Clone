using Microsoft.Xna.Framework;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Enemies.Goomba;
using Sprint5.Entities.Enemies.Koopa;
using Sprint5.Entities.Enemies.Lakitu;
using Sprint5.Entities.Items;
using Sprint5.Entities.World;
using Sprint5.Physics.Vectors;
using Sprint5.Physics.Vectors.Limits;
using Sprint5.World.Background;
using Sprint5.World.Blocks;
using Sprint5.World.Pipes;
using System.Collections.Generic;
using System.IO;

namespace Sprint5.World
{
    public class LevelLoader
    {
        private static readonly Dictionary<string, ElementLoader> loaders = new Dictionary<string, ElementLoader>();

        static void LevelLoader_Block1()
        {
            // Block loaders
            loaders.Add("indBrick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new BrickIndestructable());
            });

            loaders.Add("grBrick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new GroundBrick());
            });

            loaders.Add("hidBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new HiddenBlock(game, new MushroomOneUp(game, x, y - 1)));
            });

            loaders.Add("multiBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new MultiCoinBlock(game, new Coin(game, new Vector2(x, y - 1))));

            });

            loaders.Add("usedBlock", (game, x, y) =>
            {
                QuestionBlock block = new QuestionBlock(game, null);
                block.Hit(null);
                game.Map.SetBlock(x, y, block);
            });

            loaders.Add("FireBlock", (game, x, y) =>
            {
                IBlock block = new FireBlock(game, x, y);
                game.Map.SetBlock(x, y, block);
            });

            loaders.Add("grayFixBlock", (game, x, y) =>
            {
                IBlock block = new GrayFixBlock();
                game.Map.SetBlock(x, y, block);
            });

            loaders.Add("UGBrick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new UGBrick(game));
            });

            loaders.Add("UGgrBrick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new UGGroundBrick());
            });

            loaders.Add("GrayBrick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new GrayBrick());
            });
        }

        static void LevelLoader_Block2()
        {
            loaders.Add("brick", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new Brick(game));
            });
            loaders.Add("coinBlock", (game, x, y) =>
            {
                IItem coin = new Coin(game, new Vector2(x, y - 1));
                coin.AutoCosume(50);
                coin.Velocity = new LVector2(Coin.popVelocity.Vector, Limit<Vector2>.NONE);
                game.Map.SetBlock(x, y, new QuestionBlock(game, coin));
            });
            loaders.Add("mushroomBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new QuestionBlock(game, new Mushroom(game, x, y - 1)));
            });
            loaders.Add("oneUpBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new QuestionBlock(game, new MushroomOneUp(game, x, y - 1)));
            });
            loaders.Add("flowerBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new QuestionBlock(game, new FireFlower(game, x, y)));
            });
            loaders.Add("starBlock", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new QuestionBlock(game, new Star(game, x, y)));
            });

            loaders.Add("step", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new Steps());
            });

            loaders.Add("Princess", (game, x, y) =>
            {
                game.Map.SetBlock(x, y, new Princess());
                game.Map.SetHiddenBlock(x, y - 1, new HiddenBlock(game, null));
            });

            loaders.Add("Bridge", (game, x, y) => { game.Map.SetBlock(x, y, new Bridge()); });
        }

        static LevelLoader()
        {
            // Mario loader
            loaders.Add("mario", (game, x, y) =>
            {
                game.Mario = new Entities.Mario.Mario(game, x, y);
            });

            LevelLoader_Block1();
            LevelLoader_Block2();

            // Enemy loaders
            loaders.Add("goomba", (game, x, y) =>
            {
                game.WorldLoader.Enemies.Add(new Goomba(game, x, y));
            });
            loaders.Add("koopa", (game, x, y) =>
            {
                game.WorldLoader.Enemies.Add(new Koopa(game, x, y));
            });
            loaders.Add("boss", (game, x, y) =>
            {
                game.WorldLoader.Enemies.Add(new Bowser(game, x - 1, y - 1));
            });

            loaders.Add("lakitu", (game, x, y) =>
            {
                game.WorldLoader.Enemies.Add(new Lakitu(game, x, y));
            });

            // Pipe loader
            loaders.Add("pipeTop", (game, x, y) =>
            {
                Pipe pipe = new Pipe("Top", game)
                {
                    Position = new Vector2(x, y)
                };
                game.WorldLoader.Pipes.Add(pipe);
                game.Map.SetBlock(x, y, pipe);
                game.Map.SetHiddenBlock(x, y + 1, pipe);
                game.Map.SetHiddenBlock(x + 1, y, pipe);
                game.Map.SetHiddenBlock(x + 1, y + 1, pipe);
            });

            loaders.Add("UGpipeTop", (game, x, y) =>
            {
                Pipe pipe = new Pipe("UGTop", game);
                pipe.Position = new Vector2(x, y);
                game.WorldLoader.Pipes.Add(pipe);
                game.Map.SetBlock(x, y, pipe);
                game.Map.SetHiddenBlock(x, y + 1, pipe);
                game.Map.SetHiddenBlock(x + 1, y, pipe);
                game.Map.SetHiddenBlock(x + 1, y + 1, pipe);
            });

            loaders.Add("pipeBody", (game, x, y) =>
            {
                Pipe pipeBody = new Pipe("Body", game);
                pipeBody.Position = new Vector2(x, y);
                game.WorldLoader.Pipes.Add(pipeBody);
                game.Map.SetBlock(x, y, pipeBody);
                game.Map.SetHiddenBlock(x + 1, y, pipeBody);
            });

            loaders.Add("SWPipeEntrance", (game, x, y) =>
            {
                Pipe pipeBody = new Pipe("SWEntrance", game);
                pipeBody.Position = new Vector2(x, y);
                game.WorldLoader.Pipes.Add(pipeBody);
                game.Map.SetBlock(x, y, pipeBody);
                game.Map.SetHiddenBlock(x + 1, y, pipeBody);
                game.Map.SetHiddenBlock(x, y + 1, pipeBody);
                game.Map.SetHiddenBlock(x + 1, y + 1, pipeBody);
            });

            loaders.Add("SWPipeBody", (game, x, y) =>
            {
                Pipe pipeBody = new Pipe("SWBody", game);
                pipeBody.Position = new Vector2(x, y);
                game.WorldLoader.Pipes.Add(pipeBody);
                game.Map.SetBlock(x, y, pipeBody);
                game.Map.SetBlock(x, y + 1, pipeBody);

            });

            //Item loaders
            loaders.Add("coin", (game, x, y) =>
            {
                IItem coin = new Coin(game, new Vector2(x, y - 1));
                coin.Position = new Vector2(x, y);
                game.WorldLoader.Items.Add(coin);
            });

            loaders.Add("flagPole", (game, x, y) =>
            {
                IItem flagPole = new FlagPole(game);
                flagPole.Position = new Vector2(x, y);
                flagPole.Bounds = new Rectangle(x, y, 1, 12 - y);
                game.WorldLoader.Items.Add(flagPole);
            });

            // Background loaders
            loaders.Add("bush", (game, x, y) =>
            {
                IBackground bush = new Bush();
                bush.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(bush);
            });

            loaders.Add("bushMid", (game, x, y) =>
            {
                IBackground bushmid = new BushMid();
                bushmid.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(bushmid);
            });

            loaders.Add("bushLong", (game, x, y) =>
            {
                IBackground bushlong = new BushLong();
                bushlong.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(bushlong);
            });

            loaders.Add("hill", (game, x, y) =>
            {
                IBackground hill = new Hill();
                hill.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(hill);
            });

            loaders.Add("cloud", (game, x, y) =>
            {
                IBackground cloud = new Cloud();
                cloud.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(cloud);
            });

            loaders.Add("cloudMid", (game, x, y) =>
            {
                IBackground cloudMid = new CloudMid();
                cloudMid.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(cloudMid);
            });

            loaders.Add("cloudLong", (game, x, y) =>
            {
                IBackground cloudlong = new CloudLong();
                cloudlong.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(cloudlong);
            });

            loaders.Add("castle", (game, x, y) =>
            {
                IBackground castle = new ToadCastle();
                castle.Position = new Vector2(x, y);
                game.WorldLoader.Background.Add(castle);
            });

            loaders.Add("flag", (game, x, y) =>
            {
                Flag flag = new Flag(new Vector2(x, y));
                game.WorldLoader.Background.Add(flag);
            });

            loaders.Add("lavaTop", (game, x, y) =>
            {
                IBackground lavatop = new LavaTop { Position = new Vector2(x, y) };
                game.WorldLoader.Background.Add(lavatop);
            });

            loaders.Add("LavaBot", (game, x, y) => {
                IBackground lavatop = new LavaBot { Position = new Vector2(x, y) };
                game.WorldLoader.Background.Add(lavatop);
            });

            loaders.Add("BridgeChain", (game, x, y) => {
                IBackground bc = new BridgeChain { Position = new Vector2(x, y) };
                game.WorldLoader.Background.Add(bc);
            });

            loaders.Add("Hammer", (game, x, y) => {
                game.WorldLoader.Items.Add(new Hammer(game, new Vector2(x, y)));
            });

        }

        public LevelLoader(Game1 game, string levelFile)
        {
            game.BackgroundColor = Color.CornflowerBlue;

            int rows = 0;
            int columns = 0;
            List<string[]> elements = new List<string[]>();

            StreamReader reader = new StreamReader(levelFile);
            while (!reader.EndOfStream)
            {
                string[] element = reader.ReadLine().Split(',');
                if (element[0].ToLower() == "black")
                {
                    game.BackgroundColor = Color.Black;
                    continue;
                }
                rows++;
                if (element.Length > columns)
                {
                    columns = element.Length;
                }
                elements.Add(element);
            }

            game.Map = new Level(columns, rows);

            for (int r = 0; r < rows; r++)
            {
                string[] row = elements[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if (loaders.ContainsKey(row[c]))
                    {
                        loaders[row[c]].Invoke(game, c, r);
                    }
                    else if (row[c] != "_")
                    {
                        System.Console.WriteLine("Unknown component: " + row[c]);
                    }
                }
            }
        }

        private delegate void ElementLoader(Game1 game, int x, int y);
    }

}
