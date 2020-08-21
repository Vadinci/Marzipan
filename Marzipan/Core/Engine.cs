using System;
using System.Collections.Generic;

using Marzipan.Core.InternalLists;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marzipan.Core
{
	public class Engine : Game
	{
		public static Engine Instance { get; private set; }

		private GraphicsDeviceManager Graphics;

		public static SceneList Scenes { get; private set; }

		public Action OnBegin;

		public static int Width { get; private set; }
		public static int Height { get; private set; }
		public static int ViewWidth { get; private set; }
		public static int ViewHeight { get; private set; }

		public static Color ClearColor = Color.CornflowerBlue;

		public static Viewport Viewport { get; private set; }
		public static Matrix ScreenMatrix;


		public Engine(int width, int height, int windowWidth, int windowHeight, string title, bool fullScreen)
		{
			if (Instance != null)
			{
				throw new Exception("Engine instance already created!");
			}
			Instance = this;

			//TODO figure out what this is exactly
			Graphics = new GraphicsDeviceManager(this);

			//TODO figure out what this does exactly
			Content.RootDirectory = "Content";

			Scenes = new SceneList();

			Width = width;
			Height = height;

			//TODO improve similar to Monocles set up per device
			Graphics.PreferredBackBufferWidth = windowWidth;
			Graphics.PreferredBackBufferHeight = windowHeight;
			Graphics.IsFullScreen = fullScreen;
		}

		protected override void Initialize() {
			base.Initialize();

			Input.Initialize();
		}

		protected override void LoadContent() {
			base.LoadContent();

			//TODO check Monocle to figure out the graphiscdevice event handlers, and see when this _should_ be called
			UpdateView();

			Marzipan.Graphics.GraphicsUtils.Initialize(GraphicsDevice);

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

			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
				//TODO can't be used on all platforms,
				//needs conditional compilation
				this.Exit();
				return;
			}

			Input.Update();
			UpdateCore(gameTime);

			base.Update(gameTime);
		}

		//override for custom gameloop
		protected virtual void UpdateCore(GameTime gameTime) {
			Scenes.Update();
		}


		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(ClearColor);

			DrawCore(gameTime);

			base.Draw(gameTime);

			//TODO can we figure out the draw calls? for graphing?
			//Nice IMGUI thingy :+1:
			//GraphicsDevice.Metrics
		}

		protected virtual void DrawCore(GameTime gameTime) {
			Scenes.Draw();
		}


		private void UpdateView()
		{
			float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
			float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

			// get View Size
			if (screenWidth / Width > screenHeight / Height)
			{
				ViewWidth = (int)(screenHeight / Height * Width);
				ViewHeight = (int)screenHeight;
			}
			else
			{
				ViewWidth = (int)screenWidth;
				ViewHeight = (int)(screenWidth / Width * Height);
			}

			// apply View Padding
			var aspect = ViewHeight / (float)ViewWidth;
			//ViewWidth -= ViewPadding * 2;
			//ViewHeight -= (int)(aspect * ViewPadding * 2);

			// update screen matrix
			ScreenMatrix = Matrix.CreateScale(ViewWidth / (float)Width);

			// update viewport
			Viewport = new Viewport
			{
				X = (int)(screenWidth / 2 - ViewWidth / 2),
				Y = (int)(screenHeight / 2 - ViewHeight / 2),
				Width = ViewWidth,
				Height = ViewHeight,
				MinDepth = 0,
				MaxDepth = 1
			};
		}
	}
}
