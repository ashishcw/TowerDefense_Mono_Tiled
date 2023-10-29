
using Microsoft.Xna.Framework;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using RPG_Demo.Managers.Animation;

namespace RPG_Demo.GameObjects.Player
{
    internal class Player : GameObjects
    {
        public static Player Instance { get; private set; }

        AnimationManager animationManager;

        internal enum Animations
        {
            idleDown,
            walkDown,
            walkUp,
            walkLeft,
            walkRight,
        }
        internal Animations animation = Animations.idleDown;
        //internal Microsoft.Xna.Framework.Vector2 position;
        //public Player(AnimatedSprite animatedSprite, Vector2 position)
        public Player()
        {
            var spriteSheet = Globals.Content.Load<SpriteSheet>("Sprites/Character/character.sf", new JsonContentLoader());
            
            this.animatedSprite = new AnimatedSprite(spriteSheet);            

            
            //this.Position = new Microsoft.Xna.Framework.Vector2(220f, 150f);//(220, 150);
            //this.Position = position = new Microsoft.Xna.Framework.Vector2(220f, 150f);//(220, 150);
            this.Position = new Microsoft.Xna.Framework.Vector2(220f, 150f);//(220, 150);

            this.Speed = 0.9f;

            this.animationManager = new AnimationManager(spriteSheet, this.animatedSprite, this.Position, this.animation.ToString());

            if(Instance == null )
            {
                Instance = this;
            }
        }

        internal void Idle()
        {
            if (this.animationManager != null)
            {
                this.animationManager.animationToPlay = Animations.idleDown.ToString();                
            }
        }

        internal void WalkUp()
        {
            if (this.animationManager != null)
            {
                this.animationManager.animationToPlay = Animations.walkUp.ToString();                
                this.Position.Y -= this.Speed;
                this.animationManager.position = this.Position;
                //this.Position = new Microsoft.Xna.Framework.Vector2(-this.Speed, -this.Speed);
            }
        }

        internal void WalkDown()
        {
            if (this.animationManager != null)
            {
                this.animationManager.animationToPlay = Animations.walkDown.ToString();
                this.Position.Y += this.Speed;
                this.animationManager.position = this.Position;
            }
        }

        internal void WalkRight()
        {
            if (this.animationManager != null)
            {
                this.animationManager.animationToPlay = Animations.walkRight.ToString();

                this.Position.X += this.Speed;
                this.animationManager.position = this.Position;
            }
        }

        internal void WalkLeft()
        {
            if (this.animationManager != null)
            {
                this.animationManager.animationToPlay = Animations.walkLeft.ToString();
                this.Position.X -= this.Speed;
                this.animationManager.position = this.Position;
            }
        }
        
    }
}
