namespace Sprint5.Entities.Movement
{
    public interface IMovement
    {
        bool IsOnGround(IMoving entity);

        void MoveEntity(IMoving entity, float x, float y);
    }
}
