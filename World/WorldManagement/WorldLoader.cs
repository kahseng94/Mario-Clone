using Microsoft.Xna.Framework;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Items;
using Sprint5.Entities.Projectiles;
using Sprint5.World.Background;
using Sprint5.World.Blocks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Collections;

namespace Sprint5.World.WorldManagement
{
    public class WorldLoader
    {
        public Collection<IItem> Items { get; set; }
        public Collection<IProjectile> Fireballs { get; set; }
        public Collection<IEnemy> Enemies { get; set; }
        public Collection<IBlock> Pipes { get; set; }
        public Collection<IBackground> Background { get; set; }
        public Collection<IItem> Texts { get; set; }
        public Collection<IItem> MovingTexts { get; set; }
        public IList Achievements { get; } = new ArrayList();
        public string LevelName { get; private set; }

        public void InitializeLists()
        {
            Items = new Collection<IItem>();
            Fireballs = new Collection<IProjectile>();
            Enemies = new Collection<IEnemy>();
            Pipes = new Collection<IBlock>();
            Background = new Collection<IBackground>();
            Texts = new Collection<IItem>();
            MovingTexts = new Collection<IItem>();
            Achievements.Clear();
        }
        public void LoadWorld(string levelName, Game1 game, bool clearMario = true)
        {
            var state = (game.Mario == null) ? null : game.Mario.State;
            game.LevelName = levelName;
            game.Map = null;
            game.Mario = null;
            Items.Clear();
            Enemies.Clear();
            Fireballs.Clear();
            Pipes.Clear();
            Background.Clear();
            Texts.Clear();
            MovingTexts.Clear();
            Achievements.Clear();
            Game1.Camera.Position = Vector2.Zero;
            LevelName = levelName;
            string level = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\Content\\Levels\\" + levelName + ".csv";
            new LevelLoader(game, level);
            if (!clearMario)
            {
                if (state.Name == "Big") game.Mario.ToBig();
                else if (state.Name == "Fire") game.Mario.ToFire();
            }
        }
    }
}
