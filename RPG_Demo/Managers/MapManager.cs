using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Demo.Managers
{
    internal class MapManager
    {
        public static MapManager Instance;

        TiledMap _tiledMap;

        TiledMapRenderer _tiledMapRenderer;

        internal int mapWidth, mapHeight;

        internal float tileWidth, tileHeight;

        public MapManager(GraphicsDevice graphicsDevice) 
        {   
            this._tiledMap = Globals.Content.Load<TiledMap>("Map/FirstTestMap-2");
            this._tiledMapRenderer = new TiledMapRenderer(graphicsDevice, this._tiledMap);
            
            this.mapWidth = this._tiledMap.Width;
            this.mapHeight = this._tiledMap.Height;
            this.tileWidth = this._tiledMap.TileWidth;
            this.tileHeight = this._tiledMap.TileHeight;

            Instance = this;
        }


        internal void Update(GameTime gt)
        {
            if (this._tiledMapRenderer != null)
            {
                this._tiledMapRenderer.Update(gt);
            }
        }

        internal void Draw(GameTime gameTime, Matrix matrix)
        {
            if(this._tiledMapRenderer != null)
            {
                this._tiledMapRenderer.Draw(matrix);                
            }
        }


    }
}
