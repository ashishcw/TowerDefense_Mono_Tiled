using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using RPG_Demo.Managers;

namespace RPG_Demo
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;        

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //Globals.WindowSize = new Point(1280, 720); //Default window size
            Globals.WindowSize = new Point(800, 800); //Default window size
        }

        protected override void Initialize()
        {            
            this._graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            this._graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            this._graphics.ApplyChanges();

            Globals.Content = this.Content;

            GameManager gameManager = new GameManager(this.GraphicsDevice, this.Window);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = this._spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GameManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameManager.Instance.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}