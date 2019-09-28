using Microsoft.Xna.Framework.Input;

namespace Sprint5.Controllers
{
    public class KeyReleased : IKeyStatus
    {
        public Keys Key { get; set; }

        public KeyReleased(Keys k) {
            Key = k;
        }
    }
}
