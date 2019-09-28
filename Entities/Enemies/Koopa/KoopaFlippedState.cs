using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities.Movement;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class KoopaFlippedState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;
        private Game1 game;

        public KoopaFlippedState(Game1 game, Koopa koopa)
        {
            this.koopa = koopa;
            this.game = game;
            koopaSprite = KoopaSpriteFactory.Instance.CreateKoopaFlippedSprite();
        }

        public void ChangeDirection()
        {
            //NO OP
        }

        public void FinishDirection()
        {
        }

        public void BeFlipped()
        {
            koopa.Movement = new DeadMovement(game);
        }

        public void BeStomped()
        {
            koopa.Movement = new DeadMovement(game);
        }

        public bool IsAlive()
        {
            return false;
        }

        public void Update(GameTime gameTime)
        {
            koopaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location);
        }
    }
}
