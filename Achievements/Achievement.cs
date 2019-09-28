using Sprint5.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Achievements
{
    class Achievement
    {
        private bool unlock;
        private ISprite achievementSprite;
        private Vector2 position;

        public Achievement(ISprite achSprite, Vector2 pos)
        {
            this.unlock = true;
            this.achievementSprite = achSprite;
            this.position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (unlock)
            {
                achievementSprite.Draw(spriteBatch, position);
            }
        }
    }
}
