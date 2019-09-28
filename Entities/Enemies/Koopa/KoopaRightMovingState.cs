using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Enemies;

namespace Sprint5.Entities.Enemies.Koopa
{
    public class KoopaRightMovingState : IEnemyState
    {
        private Koopa koopa;
        private ISprite koopaSprite;
        private Game1 game;

        public KoopaRightMovingState(Game1 game, Koopa koopa)
        {
            this.koopa = koopa;
            this.game = game;
            koopaSprite = KoopaSpriteFactory.Instance.CreateKoopaRightMovingSprite();
        }

        public void ChangeDirection()
        {
            koopa.State = new KoopaLeftMovingState(game, koopa);
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
            koopa.Movement.MoveEntity(koopa, koopa.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000f, 0);

            koopaSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaSprite.Draw(spriteBatch, location);
        }
    }
}
