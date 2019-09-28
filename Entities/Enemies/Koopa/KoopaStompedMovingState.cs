using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class KoopaStompedMovingState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;
        private Game1 game;
        private float speed = 3;

        private int stompDelay = 100;

        public KoopaStompedMovingState(Game1 game, Koopa koopa)
        {
            this.koopa = koopa;
            this.game = game;
            koopaSprite = KoopaSpriteFactory.Instance.CreateKoopaStompedSprite();
            this.speed *= koopa.Speed;
        }

        public void ChangeDirection()
        {
            speed *= -1;
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
                koopa.State = new KoopaStompedState(game, koopa);
            }
        }

        public void Unstomp()
        {
            //NO OP
        }

        public bool IsAlive()
        {
            // Should be true when physics and koopa movement are implemented
            return stompDelay == 0;
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

            koopa.Movement.MoveEntity(koopa, speed * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);

            koopaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location);
        }
    }
}
