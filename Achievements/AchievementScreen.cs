using Sprint5.Entities.Items;
using Sprint5.Entities.Mario;
using Sprint5.Sprites;
using Sprint5.World;
using Sprint5.World.Sounds;
using Microsoft.Xna.Framework;
using Sprint5.Sprites.Achievements;

namespace Sprint5.Achievements
{
    public static class AchievementScreen
    {
        private const int SHOW_ACH_DURATION = 200;
        private static int showAchievementsRemaining = 0;

        private static ISprite millionaireSprite;
        private static ISprite speedRunSprite;
        private static ISprite worldClearSprite;
        private static string level;

        public static void ShowAchievements(Game1 game, string levelLoad)
        {
            showAchievementsRemaining = SHOW_ACH_DURATION;

            SetBackground(game);

            level = levelLoad;

            if (game.AchiTracker.MillionaireIsUnlocked)
            {
                millionaireSprite = AchievementSpriteFactory.Instance.CreateMillionaireSprite();
            }
            else
            {
                millionaireSprite = AchievementSpriteFactory.Instance.CreateLockSprite();
            }
            if (game.AchiTracker.SpeedRunIsUnlocked)
            {
                speedRunSprite = AchievementSpriteFactory.Instance.CreateSpeedRunSprite();
            }
            else
            {
                speedRunSprite = AchievementSpriteFactory.Instance.CreateLockSprite();
            }
            if (game.AchiTracker.WorldClearIsUnlocked)
            {
                worldClearSprite = AchievementSpriteFactory.Instance.CreateWorldClearSprite();
            }
            else
            {
                worldClearSprite = AchievementSpriteFactory.Instance.CreateLockSprite();
            }

            string millionaire = "Mario collected\r\n  all coins!";
            string speedRun = " Mario finished\r\n the level\r\n in less than \r\n  60 seconds!";
            string worldClear = "Mario killed\r\n all the enemies!";

            game.WorldLoader.Texts.Add(new TextItem("ACHIEVEMENTS", new Vector2(300, 100)));

            game.WorldLoader.Achievements.Add(new Achievement(millionaireSprite, new Vector2(1, 5)));
            game.WorldLoader.Achievements.Add(new Achievement(speedRunSprite, new Vector2(9.5f, 5)));
            game.WorldLoader.Achievements.Add(new Achievement(worldClearSprite, new Vector2(18.5f, 5)));

            game.WorldLoader.Texts.Add(new TextItem(millionaire, new Vector2(15, 360)));
            game.WorldLoader.Texts.Add(new TextItem(speedRun, new Vector2(290, 350)));
            game.WorldLoader.Texts.Add(new TextItem(worldClear, new Vector2(555, 360)));
        }

        private static void SetBackground(Game1 game)
        {
            game.Map = new Level(24, 6);
            game.Mario = new Mario(game, -1, 6);
            game.WorldLoader.Items.Clear();
            game.WorldLoader.Enemies.Clear();
            game.WorldLoader.Fireballs.Clear();
            game.WorldLoader.Pipes.Clear();
            game.WorldLoader.Background.Clear();
            game.WorldLoader.Texts.Clear();
            game.WorldLoader.MovingTexts.Clear();
            game.WorldLoader.Achievements.Clear();
            Game1.Camera.Position = Vector2.Zero;
            game.BackgroundColor = Color.Black;
            TextItem.game = game;
        }

        public static void Update(Game1 game)
        {
            if (showAchievementsRemaining > 0)
            {
                game.HUD.HideHUD();
                --showAchievementsRemaining;
                if (showAchievementsRemaining == 0)
                {
                    if (level != "NONE")
                    {
                        game.WorldLoader.LoadWorld(level, game, false);
                    }
                    else
                    {
                        if (Game1.Lives == 0)
                        {
                            game.WorldLoader.LoadWorld("Level1-1", game, true);
                            Game1.Lives = Game1.LIVES_INIT;
                        }
                        else
                        {
                            if (game.WorldLoader.LevelName.StartsWith("UG"))
                            {
                                game.WorldLoader.LoadWorld("Level1-1", game, true);
                            }
                            else
                            {
                                game.WorldLoader.LoadWorld(game.WorldLoader.LevelName, game, true);
                            }
                        }
                    }
                    game.HUD.Reset();
                    game.AchiTracker.Reset();
                    Songs.Instance.PlaySong();
                }
            }
        }
    }
}

