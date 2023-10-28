using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace RPG_Demo
{
    public static class Globals
    {
        public static float Time { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }

        public static Point WindowSize { get; set; }

        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
        }


    }
}
