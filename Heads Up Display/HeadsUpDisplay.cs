using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Items;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Heads_Up_Display
{
    public class HeadsUpDisplay
    {
        private Game1 game;
        private SpriteFont font;
        private Vector2 textPosition;
        private Vector2 coinPosition;
        private Vector2 marioPosition;

        private ISprite coinSprite;
        private ISprite marioSprite;

        private bool hideHUD;

        private int Score;
        private int Coin;
        private string WorldLevel { get { return (game.LevelName ?? "").Replace("Level", ""); } }

        public const int TIME_INIT = 300;
        private double time;
        public double Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        private string displayString1, displayString2;

        public HeadsUpDisplay(Game1 Game, ContentManager content)
        {
            game = Game;
            font = content.Load<SpriteFont>("MarioFont");
            textPosition = new Vector2(50, 20);
            coinPosition = new Vector2(6.75f, 1.5f);
            marioPosition = new Vector2(11.5f, 1.5f);

            coinSprite = ItemSpriteFactory.Instance.CreateCoinFloatingSprite();
            marioSprite = MarioSpriteFactory.Instance.CreateSmallRightIdleSprite();

            Score = 0;
            Coin = 0;
            Time = TIME_INIT;

            displayString1 = "MARIO                          WORLD     TIME";
            displayString2 = ToString(Score, 6) + "       x" + ToString(Coin, 2) + "       x" + ToString(Game1.Lives, 2)
                + "       " + WorldLevel + "      " + ToString((int)Time, 3);
        }

        private string ToString(int number, int digits)
        {
            string s = "" + number;
            int length = s.Length;
            if (s.Length < digits)
            {
                for (int i = 0; i < digits - length; i++)
                {
                    s = "0" + s;
                }
            }
            return s;
        }

        public void Reset()
        {
            Score = 0;
            Coin = 0;
            Time = TIME_INIT;
            hideHUD = false;
        }

        public void GetScore(int score)
        {
            Score += score;
        }

        public void GetCoin()
        {
            Coin += 1;
            GetScore(200);
        }

        public int numberOfCoin()
        {
            return Coin;
        }

        public void HideHUD()
        {
            hideHUD = true;
        }

        public void Update(GameTime gameTime)
        {
            if (!hideHUD)
            {
                if (Time >= 0)
                {
                    Time -= gameTime.ElapsedGameTime.TotalSeconds;
                    coinSprite.Update(gameTime);
                    displayString2 = ToString(Score, 6) + "       x" + ToString(Coin, 2) + "       x" + ToString(Game1.Lives, 2)
                        + "       " + WorldLevel + "      " + ToString((int)Time, 3);
                    if (!Songs.Instance.hurry)
                        Songs.Instance.TimeToHurry((int)Time);
                }
                else
                {
                    Game1.Lives--;
                    game.Reset();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Time >= 0)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, displayString1, textPosition, Color.White);
                spriteBatch.DrawString(font, displayString2, textPosition + (new Vector2(0, 30)), Color.White);
                spriteBatch.End();

                coinSprite.DrawAtFixedPosition(spriteBatch, coinPosition);
                marioSprite.DrawAtFixedPosition(spriteBatch, marioPosition);
            }
        }
    }
}
