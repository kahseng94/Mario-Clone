using Sprint5;
using Sprint5.Entities.Enemies;

namespace Sprint5.Achievements
{
    public class AchievementTracker
    {
        public bool MillionaireIsUnlocked { get; set; }
        public bool SpeedRunIsUnlocked { get; set; }
        public bool WorldClearIsUnlocked { get; set; }

        private Game1 game;

        public AchievementTracker(Game1 game)
        {
            Reset();
            this.game = game;
        }

        public void Reset()
        {
            MillionaireIsUnlocked = false;
            SpeedRunIsUnlocked = false;
            WorldClearIsUnlocked = false;
        }

        public void UnlockMillionaire()
        {
            MillionaireIsUnlocked = true;
        }

        public void UnlockSpeedRun()
        {
            SpeedRunIsUnlocked = true;
        }

        public void UnlockWorldClear()
        {
            WorldClearIsUnlocked = true;
        }

        public void UpdateAchievement()
        {
            if (game.HUD.numberOfCoin() >= 50) game.AchiTracker.UnlockMillionaire();

            bool killAllEnemies = true;
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                if (enemy.IsAlive())
                {
                    killAllEnemies = false;
                }
            }
            if (killAllEnemies) game.AchiTracker.UnlockWorldClear();

        }
    }
}
