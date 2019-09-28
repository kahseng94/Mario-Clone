using Sprint5.Entities.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5.Entities.Mario.Movement
{

    internal class TextMovement : IMovement
    {

        public TextMovement()
        {
        }

        public bool IsOnGround(IMoving entity)
        {
            return false;
        }

        public void MoveEntity(IMoving entity, float x, float y)
        {
            var position = entity.Position;
            position.X += x;
            position.Y += y;
            entity.Position = position;
        }
    }
}
