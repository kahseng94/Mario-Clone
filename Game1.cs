using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Controllers;
using Sprint5.Test;
using Sprint5.Entities.Mario;
using Sprint5.Sprites.Entities.Enemies;
using Sprint5.Sprites.Entities.Items;
using Sprint5.Sprites.World;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World;
using Sprint5.CameraControls.Camera;
using Sprint5.Sprites.Entities.Projectile;
using Sprint5.World.Sounds;
using Sprint5.Heads_Up_Display;
using Sprint5.World.StateManagement;
using Sprint5.World.WorldManagement;
using Sprint5.WorldManagement;
using System.Collections.Generic;
using Sprint5.Sprites.Achievements;
using Sprint5.Achievements;
using System.Collections.ObjectModel;

namespace Sprint5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static readonly Camera Camera = new Camera();
        private Collection<IController> controllers;
        private bool isPaused = false;
        public Level Map { get; set; }
        public IPlayer Mario { get; set; }
        public Color BackgroundColor { get; set; }
        private SaveState savedWorld = new SaveState();
        private WorldLoader worldLoader = new WorldLoader();
        public const int LIVES_INIT = 3;
        public static int Lives = LIVES_INIT;
        public string LevelName { get; set; }
        public AchievementTracker AchiTracker { get; set; }

        public HeadsUpDisplay HUD
        {
            get
            {
                return hUD;
            }

            set
            {
                hUD = value;
            }
        }

        public SaveState SavedWorld
        {
            get
            {
                return savedWorld;
            }

            set
            {
                savedWorld = value;
            }
        }

        public WorldLoader WorldLoader
        {
            get
            {
                return worldLoader;
            }

            set
            {
                worldLoader = value;
            }
        }

        public Collection<IController> Controllers
        {
            get
            {
                return controllers;
            }

            set
            {
                controllers = value;
            }
        }

        public bool IsPaused
        {
            get
            {
                return isPaused;
            }

            set
            {
                isPaused = value;
            }
        }

        public bool FirstRun
        {
            get
            {
                return firstRun;
            }

            set
            {
                firstRun = value;
            }
        }

        private HeadsUpDisplay hUD;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            if (graphics.IsFullScreen)
            {
                Content.RootDirectory = "fullScreen";
            }
            Content.RootDirectory = "Content";
            WorldLoader = new WorldLoader();
            BackgroundColor = Color.CornflowerBlue;
            AchiTracker = new AchievementTracker(this);
        }

        protected override void Initialize()
        {
            Controllers = new Collection<IController>();
            WorldLoader.InitializeLists();
            GamePadController gamepad = new GamePadController(this);
            KeyboardController keyboard = new KeyboardController(this);
            keyboard.RegisterKeys(this);
            gamepad.RegisterButtons(this);
            Controllers.Add(gamepad);
            Controllers.Add(keyboard);
            Camera.SetViewportAndOrigin(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GoombaSpriteFactory.Instance.LoadAllTextures(Content);
            BowserSpriteFactory.Instance.LoadAllTextures(Content);
            KoopaSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            WorldElementSpriteFactory.Instance.LoadAllTextures(Content);
            MarioSpriteFactory.Instance.LoadAllTextures(Content);
            FireballSpriteFactory.Instance.LoadAllTextures(Content);
            AchievementSpriteFactory.Instance.LoadAllTextures(Content);
            LakituSpriteFactory.Instance.LoadAllTextures(Content);
            SoundEffects.Instance.LoadSoundEffects(Content);
            Songs.Instance.LoadSongs(Content);
            HUD = new HeadsUpDisplay(this, Content);
            WorldLoader.LoadWorld("Level1-1", this);
            Songs.Instance.PlaySong();
            Tester.RunTests(this);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            WorldUpdate.UpdateAllWorld(this, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            WorldDraw.DrawAllWorld(this, spriteBatch);
            base.Draw(gameTime);
        }

        private bool firstRun = true;

        public void Reset()
        {
            MarioLivesScreen.ShowLivesRemaining(this);
            // HUD.Reset();
        }
    }
}
