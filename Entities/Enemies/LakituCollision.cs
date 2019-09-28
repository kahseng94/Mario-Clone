using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.Entities.Enemies.Lakitu;
using System;

namespace Sprint5.Entities
{
    public class LakituCollision : ICollision
    {

        public void Handle(IEntity entity, IEntity target, Side side)
        {

        }

        public void Handle(Lakitu lakitu, Game1 game)
        {
            if (Math.Abs(lakitu.Position.X) < Math.Abs(game.Mario.Position.X - 3.5) && lakitu.Left == true)
            {
                lakitu.State.ChangeDirection();
                lakitu.Left = false;
            }
            else if (Math.Abs(lakitu.Position.X) > Math.Abs(game.Mario.Position.X + 20) && lakitu.Left == false)
            {
                lakitu.State.ChangeDirection();
                lakitu.Left = true;
            }
        }
    }
}
