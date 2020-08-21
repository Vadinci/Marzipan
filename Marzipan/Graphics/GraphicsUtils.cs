using System;
using Marzipan.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marzipan.Graphics
{
	public class GraphicsUtils
	{
		private static bool initialized = false;

		public static SpriteBatch SpriteBatch;
        public static Renderer Renderer { get; internal set; }

        public static void Initialize(GraphicsDevice graphicsDevice)
		{
			if (initialized) return;

			SpriteBatch = new SpriteBatch(graphicsDevice);

			initialized = true;
		}
	}
}
