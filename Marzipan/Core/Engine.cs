using System;
using Marzipan.Core.EngineUtil;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marzipan.Core
{
	public class Engine : Game
	{
		private GraphicsDeviceManager graphics;

		public Engine() {
			//TODO figure out what this is exactly
			graphics = new GraphicsDeviceManager(this);

			//TODO figure out what this does exactly
			Content.RootDirectory = "Content";
		}

		public void SetUp(EngineProperties properties) {
			//TODO platform stuff

			graphics.PreferredBackBufferWidth = properties.width != 0 ? properties.width : 800;
			graphics.PreferredBackBufferHeight = properties.height != 0 ? properties.height : 480;
			graphics.IsFullScreen = properties.fullScreen;
#if MOBILE
			graphics.SupportedOrientations		= properties.supportedOrientations != 0 ? properties.supportedOrientations : DisplayOrientation.Portrait;
#endif
		}

		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			base.LoadContent();
		}

		protected override void UnloadContent() {
			Content.Unload();
			base.UnloadContent();
		}

		protected override void OnActivated(object sender, EventArgs args) {
			//TODO
			base.OnActivated(sender, args);
		}

		protected override void OnDeactivated(object sender, EventArgs args) {
			//TODO
			base.OnDeactivated(sender, args);
		}

		protected override void Update(GameTime gameTime) {
			/*
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
				//TODO can't be used on all platforms,
				//needs conditional compilation
				this.Exit();
				return;
			}
			*/

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}
	}
}
