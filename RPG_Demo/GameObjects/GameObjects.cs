using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;

namespace RPG_Demo.GameObjects
{
    internal class GameObjects
    {

        protected Texture2D texture;

        public string Name;        
        public float Rotation;
        public float Scale;

        public Vector2 Position;
        public float Speed { get; set; } = 0.5f;

        public Sprite Sprite;
        public AnimatedSprite animatedSprite;
        public Rectangle rectangle;
        
        public RectangleF Bounds => Sprite.GetBoundingRectangle(Position, 0f, Vector2.One);

        public GameObjects(Vector2 pos, Texture2D texture2D, Rectangle rect)
        {
            //this.Position = Vector2.Zero;
            this.texture = texture2D;
            this.rectangle = rect;
        }

        public GameObjects() { }


    }
}
