using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Entities.Mario
{
    public interface IMarioState
    {
        string Name { get; }

        void Left();

        void Right();

        void Up();

        void Down();

        void RightReleased();

        void LeftReleased();

        void DownReleased();

        void UpReleased();

        void Use();

        void Walk();

        void Run();

        void ToBig();

        void ToSmall();

        void ToFire();

        void CauseDamage();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
