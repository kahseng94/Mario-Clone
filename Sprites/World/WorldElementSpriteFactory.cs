using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Sprites.World
{
    public class WorldElementSpriteFactory
    {
        public static WorldElementSpriteFactory Instance { get; } = new WorldElementSpriteFactory();

        private Texture2D pipeTop;
        private Texture2D pipeBody;
        private Texture2D SWPipeEntrance;
        private Texture2D SWPipeBody;
        private Texture2D bush;
        private Texture2D bushMid;
        private Texture2D bushLong;
        private Texture2D hill;
        private Texture2D cloud;
        private Texture2D cloudMid;
        private Texture2D cloudLong;
        private Texture2D toadCastle;
        private Texture2D toadFlagPole;
        private Texture2D toadFlag;
        private Texture2D toadCastleFlag;
        private Texture2D bridge;
        private Texture2D bridgeChain;
        private Texture2D lavaTop;
        private Texture2D lavaBot;


        private WorldElementSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            pipeTop = content.Load<Texture2D>("Pipes\\PipeUprightTop");
            pipeBody = content.Load<Texture2D>("Pipes\\PipeUprightBody");
            SWPipeBody = content.Load<Texture2D>("Pipes\\PipeSidewaysBody");
            SWPipeEntrance = content.Load<Texture2D>("Pipes\\PipeSidewaysEntrance");
            bush = content.Load<Texture2D>("BgElements\\bush");
            bushMid = content.Load<Texture2D>("BgElements\\bushMid");
            bushLong = content.Load<Texture2D>("BgElements\\bushLong");
            hill = content.Load<Texture2D>("BgElements\\hill");
            cloud = content.Load<Texture2D>("BgElements\\cloud");
            cloudMid = content.Load<Texture2D>("BgElements\\cloudMid");
            cloudLong = content.Load<Texture2D>("BgElements\\cloudLong");
            toadCastle = content.Load<Texture2D>("BgElements\\ToadCastle");
            toadFlagPole = content.Load<Texture2D>("BgElements\\FlagPole");
            toadFlag = content.Load<Texture2D>("BgElements\\Flag");
            toadCastleFlag = content.Load<Texture2D>("BgElements\\FlagToadCastle");
            bridge = content.Load<Texture2D>("Level 1-4\\bridge");
            bridgeChain = content.Load<Texture2D>("Level 1-4\\bridgeChain");
            lavaTop = content.Load<Texture2D>("Level 1-4\\lavaTop");
            lavaBot = content.Load<Texture2D>("Level 1-4\\lavaBot");
        }

        public ISprite CreatePipeTopSprite()
        {
            return new StaticSprite(pipeTop);
        }

        public ISprite CreatePipeTopBodySprite()
        {
            return new StaticSprite(pipeBody);
        }


        public ISprite CreateSWPipeEntranceSprite()
        {
            return new StaticSprite(SWPipeEntrance);
        }

        public ISprite CreateSWPipeBodySprite()
        {
            return new StaticSprite(SWPipeBody);
        }

        public ISprite CreateBushSprite()
        {
            return new StaticSprite(bush);
        }

        public ISprite CreateBushMidSprite()
        {
            return new StaticSprite(bushMid);
        }

        public ISprite CreateBushLongSprite()
        {
            return new StaticSprite(bushLong);
        }
        public ISprite CreateHillSprite()
        {
            return new StaticSprite(hill);
        }

        public ISprite CreateCloudSprite()
        {
            return new StaticSprite(cloud);
        }

        public ISprite CreateCloudMidSprite()
        {
            return new StaticSprite(cloudMid);
        }

        public ISprite CreateCloudLongSprite()
        {
            return new StaticSprite(cloudLong);
        }

        public ISprite CreateToadCastleSprite()
        {
            return new StaticSprite(toadCastle);
        }

        public ISprite CreateToadFlagPoleSprite()
        {
            return new StaticSprite(toadFlagPole);
        }

        public ISprite CreateToadFlagSprite()
        {
            return new StaticSprite(toadFlag);
        }
        public ISprite CreateCastleFlagSprite()
        {
            return new StaticSprite(toadCastleFlag);
        }

        public ISprite CreateBridgeSprite()
        {
            return new StaticSprite(bridge);
        }
        public ISprite CreateBridgeChainSprite()
        {
            return new StaticSprite(bridgeChain);
        }
        public ISprite CreateLavaTopSprite()
        {
            return new StaticSprite(lavaTop, 0, 0, 16, 11, 0, (float)5 / 16);

        }
        public ISprite CreateLavaBotSprite()
        {
            return new StaticSprite(lavaBot);
        }
    }
}
