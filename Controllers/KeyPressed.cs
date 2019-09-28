using Microsoft.Xna.Framework.Input;

namespace Sprint5.Controllers
{
    public class KeyPressed : IKeyStatus
    {
        public Keys Key { get; set; }

        public KeyPressed(Keys k) {
            Key = k;
        }
    }
}
