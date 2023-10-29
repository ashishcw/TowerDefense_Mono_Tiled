using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;
using RPG_Demo.GameObjects;

namespace RPG_Demo.Managers.Animation
{
    internal class AnimationManager
    {
        public static AnimationManager Instance { get; private set; }

        public static AnimationManager getInstance()
        {
            if (Instance == null)
            {
                Instance = new AnimationManager();
            }
            return Instance;
        }
        internal SpriteSheet spriteSheet;
        internal AnimatedSprite animatedSprite;
        internal Vector2 position;
        internal string animationToPlay;

        public AnimationManager()
        {
            
        }
        public AnimationManager(SpriteSheet spriteSheet, AnimatedSprite animatedSprite, Vector2 pos, string animationToPlay = "")
        {
            this.spriteSheet = spriteSheet;
            this.animatedSprite = animatedSprite;
            this.position = pos;            
            this.animationToPlay = animationToPlay;

            if (Instance == null)
            {
                Instance = this;
            }

            
        }

        internal void Update(GameTime gameTime)
        {
            if (animatedSprite != null)
            {
                if (!string.IsNullOrEmpty(this.animationToPlay))
                {
                    animatedSprite.Play(this.animationToPlay);
                    animatedSprite.Update(gameTime);
                }
                
            }
        }

        internal void Draw()
        {
            if (animatedSprite != null)
            {
                Globals.SpriteBatch.Draw(this.animatedSprite, this.position);
            }
            
        }
    }
}
