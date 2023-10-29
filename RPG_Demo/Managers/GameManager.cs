using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using RPG_Demo.GameObjects.Player;
using RPG_Demo.Managers.Animation;
using RPG_Demo.Managers.Camera;
using System;
using System.Diagnostics;

namespace RPG_Demo.Managers
{
    internal class GameManager
    {
        public static GameManager Instance;
        private readonly MapManager mapManager;
        private readonly CameraManager cameraManager;
        private readonly Player player;
        //private readonly Charactor charactor;

        private AnimatedSprite _motwSprite, _motwSprite2, _motwSprite3, _motwSprite4, _motwSprite5;
        private Vector2 _motwPosition;

        public GameManager(GraphicsDevice gd, GameWindow window) 
        {
            //Map instantiate
            this.mapManager = new MapManager(gd);
            
            this.cameraManager = new CameraManager(
                window, 
                gd, 
                this.mapManager.mapWidth * (int)this.mapManager.tileWidth,
                this.mapManager.mapHeight * (int)this.mapManager.tileHeight
                );
            
            this.player = new Player();

            Instance = this;
        }

        internal void Update(GameTime gt)
        {
            MapManager.Instance?.Update(gt);

            CameraManager.Instance.GetMousePosition();
            
            InputManager.getInstance().BasicMovement(gt);            

            AnimationManager.Instance?.Update(gt);
            
        }

        internal void Draw(GameTime gt)
        {
            var transformMatrix = this.cameraManager.camera.GetViewMatrix();

            Globals.SpriteBatch?.Begin(transformMatrix: transformMatrix);
            
            //Map manager
            MapManager.Instance?.Draw(gt, transformMatrix);

            //Animation manager
            AnimationManager.Instance?.Draw();

            Globals.SpriteBatch?.End();

        }
    }
}
