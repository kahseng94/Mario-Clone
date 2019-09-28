using System.Collections.Generic;

namespace Sprint5.Test
{
    public abstract class Tester
    {
        protected static readonly bool enabled = true;
        protected static readonly ICollection<Tester> testers = new List<Tester>();

        static Tester()
        {
            testers.Add(new CollisionTester());
        }

        public static void RunTests(Game1 game)
        {
            if (enabled)
            {
                foreach (Tester tester in testers)
                {
                    tester.RunTest(game);
                }
                game.Reset();
            }
        }

        public abstract void RunTest(Game1 game);
    }

    public delegate bool Test(Game1 game);
}
