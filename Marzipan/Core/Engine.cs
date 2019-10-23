using System;
using System.Collections.Generic;
using Marzipan.Core.EngineUtil;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marzipan.Core
{
	public class Engine : Game
	{
		private GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;

		public List<Entity> entities = new List<Entity>();

		public Action OnBegin;

		public Engine() {
			//TODO figure out what this is exactly
			graphics = new GraphicsDeviceManager(this);

			//TODO figure out what this does exactly
			Content.RootDirectory = "Content";
		}

		public void SetUp(EngineProperties properties) {
			//TODO platform stuff
			int defWidth = 800;
			int defHeight = 480;

			if (properties.fullScreen) {
				defWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
				defHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}

			graphics.PreferredBackBufferWidth = properties.width != 0 ? properties.width : defWidth;
			graphics.PreferredBackBufferHeight = properties.height != 0 ? properties.height : defHeight;
			graphics.IsFullScreen = properties.fullScreen;

#if MOBILE
			graphics.SupportedOrientations = properties.supportedOrientations != 0 ? properties.supportedOrientations : DisplayOrientation.Portrait;
#endif
		}

		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			base.LoadContent();
			spriteBatch = new SpriteBatch(GraphicsDevice);

			if (OnBegin != null) OnBegin.Invoke();
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

			//TODO add scenes in between engine and entities (and then probably also add another layer in between there)
			foreach (Entity e in entities) {
				e.Update();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			//TODO add scenes in between engine and entities (and then probably also add another layer in between engine and scenes?)
			foreach (Entity e in entities) {
				e.Draw();
			}
			spriteBatch.End();

			base.Draw(gameTime);

			//TODO can we figure out the draw calls? for graphing?
			//Nice IMGUI thingy :+1:
			//GraphicsDevice.Metrics
		}
	}
}
