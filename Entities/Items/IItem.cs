using Sprint5.Entities.Mario;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Vectors;

namespace Sprint5.Entities.Items
{
    public interface IItem : IMoving
    {
        string Type { get; }
        float XDirection { get; set; }
        void Consume(IPlayer player);
        void AutoCosume(int v);
    }
}
