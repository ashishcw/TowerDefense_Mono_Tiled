using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Sprites;
using RPG_Demo.GameObjects.Player;
using RPG_Demo.GameObjects;
using System.Diagnostics;
using RPG_Demo.Managers.Camera;

namespace RPG_Demo.Managers
{
    /// <summary>
    /// This class is responsible to handle all the inputs(Keyboard/Mouse)
    /// </summary>
    internal class InputManager
    {
        public static InputManager Instance { get; private set; }

        public static InputManager getInstance()
        {
            if (Instance == null)
            {
                Instance = new InputManager();
            }
            return Instance;
        }



        internal void BasicMovement(GameTime gameTime)
        {
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var walkSpeed = deltaSeconds * 128;
            var keyboardState = Keyboard.GetState();            

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {   
                Player.Instance?.WalkUp();             
            }
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                Player.Instance?.WalkDown();
            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                Player.Instance?.WalkLeft();
            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {   
                Player.Instance?.WalkRight();
            }
            else
            {
                Player.Instance?.Idle();
            }


            if (keyboardState.IsKeyDown(Keys.R))
            {
                CameraManager.Instance.camera.ZoomIn(0.01f);
                //CameraManager.Instance.camera.LookAt(Player.Instance.position);                
            }

            if (keyboardState.IsKeyDown(Keys.T))
            {
                CameraManager.Instance.camera.ZoomOut(0.01f);
            }
        }


    }
}
