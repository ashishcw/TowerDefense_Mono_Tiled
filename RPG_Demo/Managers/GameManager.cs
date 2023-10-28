using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG_Demo.Managers.Camera;

namespace RPG_Demo.Managers
{
    internal class GameManager
    {
        public static GameManager Instance;
        private readonly MapManager mapManager;
        private readonly CameraManager cameraManager;
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


            Instance = this;
        }

        internal void Update(GameTime gt)
        {
            MapManager.Instance?.Update(gt);

            CameraManager.Instance.GetMousePosition();

            //this.cameraManager.camera?.Move(CameraManager.Instance.GetMovementDirection() * CameraManager.Instance.Speed * Globals.Time);
        }

        internal void Draw(GameTime gt)
        {
            var transformMatrix = this.cameraManager.camera.GetViewMatrix();

            Globals.SpriteBatch?.Begin(transformMatrix: transformMatrix);
            MapManager.Instance?.Draw(gt, transformMatrix);
            Globals.SpriteBatch?.End();

        }
    }
}
