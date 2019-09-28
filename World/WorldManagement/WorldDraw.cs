using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Items;
using Sprint5.Entities.Projectiles;
using Sprint5.World.Background;
using Sprint5.World.Pipes;
using Sprint5.Achievements;

namespace Sprint5.World.WorldManagement
{
    public static class WorldDraw
    {
        public static void DrawAllWorld(Game1 game, SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(game.BackgroundColor);
            foreach (IBackground background in game.WorldLoader.Background)
            {
                background.Draw(spriteBatch, background.Position);
            }

            game.Map.Draw(spriteBatch);
            foreach (Pipe pipe in game.WorldLoader.Pipes)
            {
                pipe.Draw(spriteBatch, pipe.Position);
            }

            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                enemy.Draw(spriteBatch, enemy.Position);
            }

            foreach (IItem item in game.WorldLoader.Items)
            {
                item.Draw(spriteBatch, item.Position);
            }

            foreach (IProjectile fireball in game.WorldLoader.Fireballs)
            {
                fireball.Draw(spriteBatch, fireball.Position);
            }

            foreach (TextItem text in game.WorldLoader.Texts)
            {
                text.Draw(spriteBatch, text.Position);
            }

            foreach (MovingText movingText in game.WorldLoader.MovingTexts)
            {
                movingText.Draw(spriteBatch, movingText.Position);
            }

            foreach (Achievement achievement in game.WorldLoader.Achievements)
            {
                achievement.Draw(spriteBatch);
            }

            game.Mario.Draw(spriteBatch, game.Mario.Position);
            game.HUD.Draw(spriteBatch);
        }
    }
}
