using Microsoft.Xna.Framework;
using Sprint5.Controllers;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Items;
using Sprint5.Entities.Projectiles;
using Sprint5.World.Background;
using Sprint5.World.Pipes;
using Sprint5.Achievements;
using Sprint5.Entities.Enemies.Lakitu;

namespace Sprint5.WorldManagement
{
    class WorldUpdate
    {
        private WorldUpdate()
        {
        }

        public static void UpdateAllWorld(Game1 game, GameTime gameTime)
        {
            Heads_Up_Display.MarioLivesScreen.Update(game);
            AchievementScreen.Update(game);
            foreach (IController controller in game.Controllers)
            {
                controller.Update();
            }

            if (game.IsPaused) return;

            game.Map.Update(gameTime);
            game.Mario.Update(gameTime);
            foreach (IItem item in game.WorldLoader.Items)
            {
                item.Update(gameTime);
            }

            foreach (IProjectile fireball in game.WorldLoader.Fireballs)
            {
                fireball.Update(gameTime);
            }

            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                enemy.FinishDirection();
            }

            { 
                bool addBall = false;
                Lakitu lakitu = null;
                foreach (IEnemy enemy in game.WorldLoader.Enemies)
                {
                    if (enemy is Lakitu)
                    {
                        lakitu = (Lakitu)enemy;
                        if (lakitu.AboveMario() && lakitu.State.thrown == false)
                        {
                            addBall = true;
                        }
                    }
                }
                if (addBall)
                {
                    game.WorldLoader.Enemies.Add(new LakituBall(game, lakitu.Position, 10));
                    lakitu.State.thrown = true;
                }
            }

            foreach (Pipe pipe in game.WorldLoader.Pipes)
            {
                pipe.Update(gameTime);
            }

            foreach (IBackground background in game.WorldLoader.Background)
            {
                background.Update(gameTime);
            }

            foreach (MovingText movingText in game.WorldLoader.MovingTexts)
            {
                movingText.Update(gameTime);
            }

            game.HUD.Update(gameTime);
        }
    }
}
