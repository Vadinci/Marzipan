using System;
using Microsoft.Xna.Framework;

namespace Marzipan.Core.EngineUtil
{
	public struct EngineProperties
	{
		public int width;
		public int height;

		public bool fullScreen;

		public DisplayOrientation supportedOrientations;   //mobile only
	}
}
