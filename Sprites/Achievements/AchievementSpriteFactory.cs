using Sprint5.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5.Sprites.Achievements
{
    class AchievementSpriteFactory
    {
        public static AchievementSpriteFactory Instance { get; } = new AchievementSpriteFactory();

        private Texture2D Millionaire;
        private Texture2D SpeedRun;
        private Texture2D WorldClear;
        private Texture2D LockAchievement;

        private AchievementSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            Millionaire = content.Load<Texture2D>("Achievements\\Millionaire");
            SpeedRun = content.Load<Texture2D>("Achievements\\Speed Run");
            WorldClear = content.Load<Texture2D>("Achievements\\World Clear");
            LockAchievement = content.Load<Texture2D>("Achievements\\Lock");
        }

        public ISprite CreateMillionaireSprite()
        {
            return new StaticSprite(Millionaire);
        }

        public ISprite CreateSpeedRunSprite()
        {
            return new StaticSprite(SpeedRun);
        }

        public ISprite CreateWorldClearSprite()
        {
            return new StaticSprite(WorldClear);
        }

        public ISprite CreateLockSprite()
        {
            return new StaticSprite(LockAchievement);
        }
    }
}
