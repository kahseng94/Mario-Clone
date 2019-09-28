using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.World;

namespace Sprint5.CameraControls.Camera
{
    public class Camera
    {
        public Viewport Viewport;
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Zoom { get; set; }
        public Vector2 Origin { get; set; }

        public Camera()
        {
            Rotation = 0;
            Zoom = 1;
            Position = Vector2.Zero;
        }

        public void SetViewportAndOrigin(Viewport viewport)
        {
            Viewport = viewport;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        }

        public void PanCamera(float step, Game1 game)
        {
            if (step>0&&Position.X < game.Map.Width*50)
            {
                Position += new Vector2(step, 0);
            }else if(step<0&&Position.X>0)
            {
                Position += new Vector2(step, 0);
            }
        }



        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                    Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Zoom, Zoom, 1) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
            }
        }
    }
}