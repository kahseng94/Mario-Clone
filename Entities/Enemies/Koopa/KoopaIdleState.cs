using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class KoopaIdleState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;
        private Game1 game;

        public KoopaIdleState(Game1 game, Koopa koopa)
        {
            this.koopa = koopa;
            this.game = game;
            koopaSprite = KoopaSpriteFactory.Instance.CreateKoopaIdleSprite();
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
            koopa.State = new KoopaFlippedState(game, koopa);
        }

        public void BeStomped()
        {
            koopa.State = new KoopaStompedState(game, koopa);
        }

        public bool IsAlive()
        {
            return true;
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
