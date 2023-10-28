using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RPG_Demo.GameObjects;
using System.Diagnostics;

namespace RPG_Demo.Managers.Camera
{
    internal class CameraManager : GameObjects.GameObjects
    {
        public static CameraManager Instance;

        internal OrthographicCamera camera;
        


        //movement
        
        public CameraManager(GameWindow window, GraphicsDevice gd, int width, int height)
        {
            //Camera Initialiazation            
            var viewportadapter = new BoxingViewportAdapter(window, gd, width, height);
            this.camera = new OrthographicCamera(viewportadapter);
            this.Speed = 200f;

            Instance = this;
        }

        internal Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                movementDirection += Vector2.UnitX;
            }
            return movementDirection;
        }

        internal Vector2 GetMousePosition()
        {
            var mouseState = Mouse.GetState();
            Vector2 _worldPosition = Vector2.One;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                _worldPosition = this.camera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y));
                Debug.WriteLine(_worldPosition.ToString());
            }   
            
            return _worldPosition;
        }

    }
}
