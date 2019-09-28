using System;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Enemies;

namespace Sprint5.Entities.Movement
{
    internal class DeadMovement : IMovement
    {
        private Game1 game;

        public DeadMovement(Game1 game)
        {
            this.game = game;
        }

        public bool IsOnGround(IMoving entity)
        {
            return false;
        }

        public void MoveEntity(IMoving entity, float x, float y)
        {
            var position = entity.Position;
            position.X += x; position.Y += y;
            entity.Position = position;
            if (position.Y > game.Map.Height)
            {
                if (entity is IPlayer)
                {
                    game.Reset();
                }
            }
        }
    }
}