using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class KoopaStompedState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;
        private Game1 game;
        private int stompDelay = 100;

        public KoopaStompedState(Game1 game, Koopa koopa)
        {
            this.koopa = koopa;
            this.game = game;
            koopaSprite = KoopaSpriteFactory.Instance.CreateKoopaStompedSprite();
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
            if (stompDelay == 0)
            {
                koopa.State = new KoopaStompedMovingState(game, koopa);
            }
        }

        public bool IsAlive()
        {
            return false;
        }

        public void Unstomp()
        {
            koopa.State = new KoopaLeftMovingState(game, koopa);
        }

        public void Update(GameTime gameTime)
        {
            if (stompDelay > 0)
            {
                stompDelay -= gameTime.ElapsedGameTime.Milliseconds;
                if (stompDelay < 0)
                {
                    stompDelay = 0;
                }
            }

            koopaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location);
        }
    }
}
