using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint5.Test
{
    public class CollisionTester : Tester
    {
        private readonly Dictionary<string, Test> tests = new Dictionary<string, Test>();

        public CollisionTester()
        {
            // Mario Block collisions
            tests.Add("Mario - Block Left", (game) => {
                return true;
            });
            tests.Add("Mario - Block Right", (game) => {
                return true;
            });
            tests.Add("Mario - Block Top", (game) => {
                return true;
            });
            tests.Add("Mario - Block Bottom", (game) => {
                return true;
            });

            // Mario collide item left
            // Mario collide item right
            // Mario collide item top
            // Mario collide item bottom

            // Mario collide enemy left
            // Mario collide enemy right
            // Mario collide enemy top
            // Mario collide enemy bottom
        }

        public override void RunTest(Game1 game)
        {
            foreach (KeyValuePair<string, Test> test in tests)
            {
                Debug.WriteLine("Collision Test \"" + test.Key + "\" " + (test.Value.Invoke(game) ? "Success" : "FAILURE"));
            }
        }
    }
}
