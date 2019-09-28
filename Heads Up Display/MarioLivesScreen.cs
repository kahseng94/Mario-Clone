using Microsoft.Xna.Framework;
using Sprint5.Entities.Items;
using Sprint5.Entities.Mario;
using Sprint5.World;
using Sprint5.World.Sounds;
using Sprint5.Achievements;

namespace Sprint5.Heads_Up_Display
{
    public class MarioLivesScreen
    {
        private const int SHOW_LIVES_DURATION = 200;
        private static int showLivesRemaining = 0;
        /// <summary>
        /// Show lives remaining
        /// </summary>
        public static void ShowLivesRemaining(Game1 game)
        {
            if (game.FirstRun)
            {
                game.FirstRun = false;
                return;
            }
            showLivesRemaining = SHOW_LIVES_DURATION;

            game.Map = new Level(24, 6);
            game.Mario = null;
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
            if (Game1.Lives <= 0)
            {
                // Game over!
                SoundEffects.Instance.PlayGameOverSound();
                game.Mario = new Mario(game, -1, 6);
                game.WorldLoader.Texts.Add(new TextItem(
                "GAME OVER!", new Vector2(256, 192)));
            }
            else
            {
                // Write lives
                game.Mario = new Mario(game, 10, 6);
                game.Mario.State = new SmallRightIdleNonResponsiveState((Mario)game.Mario);
                game.WorldLoader.Texts.Add(new TextItem("X " + Game1.Lives, new Vector2(380, 200)));
            }

        }

        public static void Update(Game1 game)
        {
            if (showLivesRemaining > 0)
            {
                --showLivesRemaining;
                if (showLivesRemaining == 0)
                {
                    AchievementScreen.ShowAchievements(game, "NONE");
                }
            }
        }
    }
}
