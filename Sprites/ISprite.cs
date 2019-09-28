using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint5.Sprites
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }

        int Width { get; }

        int Height { get; }

        float Scale { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 location);
        
        void DrawAtFixedPosition(SpriteBatch spriteBatch, Vector2 location);

        void Bump();
    }
}
