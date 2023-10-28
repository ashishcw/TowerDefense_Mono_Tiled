using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;

namespace RPG_Demo.GameObjects
{
    internal class GameObjects
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }

        public float Speed { get; set; } = 200f;

        public Sprite Sprite { get; set; }
        
        public RectangleF Bounds => Sprite.GetBoundingRectangle(Position, 0f, Vector2.One);

    }
}
