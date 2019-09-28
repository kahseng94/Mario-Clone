using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Mario
{
    public class FinishMovement : IMovement
    {
        private readonly Game1 game;

        public FinishMovement(Game1 game)
        {
            this.game = game;
        }

        public FinishMovement()
        {
        }

        public bool IsOnGround(IMoving entity)
        {
            return true;
        }

        public void MoveEntity(IMoving entity, float x, float y)
        {
            var position = entity.Position;
            position.X += x; position.Y += y;
            entity.Position = position;
        }
    }
}