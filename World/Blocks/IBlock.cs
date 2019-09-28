using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Entities;
using Sprint5.Entities.Mario;

namespace Sprint5.World.Blocks
{
    public interface IBlock : IEntity
    {
        string Type { get; }

        void Hit(IPlayer player);
    }
}
