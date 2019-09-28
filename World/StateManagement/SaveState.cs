using Microsoft.Xna.Framework;
using Sprint5.CameraControls.Camera;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Items;
using Sprint5.Entities.Projectiles;
using Sprint5.World.Background;
using Sprint5.World.Blocks;
using System.Collections;
using System.Collections.ObjectModel;

namespace Sprint5.World.StateManagement
{
    public class SaveState
    {
        public struct SavedWorld
        {
            public Level Map { get; set; }
            public Collection<IItem> Items { get; set; }
            public Collection<IProjectile> Fireballs { get; set; }
            public Collection<IEnemy> Enemies { get; set; }
            public Collection<IBlock> Pipes { get; set; }
            public Collection<IBackground> Background { get; set; }
            public Collection<IItem> Texts { get; set; }
            public Collection<IItem> MovingTexts { get; set; }
            public Color BackgroundColor { get; set; }
            public Camera Camera { get; set; }
            public string LevelName { get; set; }
            public Vector2 MarioPosition { get; set; }
        }

            public SavedWorld saved = new SavedWorld();

            public void SaveCurrentWorld(Game1 game)
            {
                
                saved.MarioPosition = new Vector2(game.Mario.Position.X, game.Mario.Position.Y);
                saved.Map = game.Map;
                saved.Items = new Collection<IItem>(game.WorldLoader.Items);
                saved.Enemies = new Collection<IEnemy>(game.WorldLoader.Enemies);
                saved.Fireballs = new Collection<IProjectile>(game.WorldLoader.Fireballs);
                saved.Pipes = new Collection<IBlock>(game.WorldLoader.Pipes);
                saved.Background = new Collection<IBackground>(game.WorldLoader.Background);
                saved.Texts = new Collection<IItem>(game.WorldLoader.Texts);
                saved.MovingTexts = new Collection<IItem>(game.WorldLoader.MovingTexts);
                saved.Camera = new Camera();
                saved.Camera.Position = Game1.Camera.Position;
                saved.Camera.Origin = Game1.Camera.Origin;
                saved.BackgroundColor = game.BackgroundColor;
                saved.LevelName = game.LevelName;
            }

            public void LoadSavedWorld(Game1 game)
            {
                game.Map = saved.Map;
                game.WorldLoader.Items = saved.Items;
                game.WorldLoader.Enemies = saved.Enemies;
                game.WorldLoader.Fireballs = saved.Fireballs;
                game.WorldLoader.Pipes = saved.Pipes;
                game.WorldLoader.Background = saved.Background;
                game.WorldLoader.Texts = saved.Texts;
                game.WorldLoader.MovingTexts = saved.MovingTexts;
                game.Mario.Position = saved.MarioPosition;
                Game1.Camera.Origin = saved.Camera.Origin;
                Game1.Camera.Position = saved.Camera.Position - new Vector2(100, 0);
                game.BackgroundColor = saved.BackgroundColor;
                game.LevelName = saved.LevelName;
            }
        }
}
