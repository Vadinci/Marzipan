using System;
using Marzipan.Core;
using Marzipan.Graphics;
using Microsoft.Xna.Framework;

namespace Marzipan.Components.Graphics
{
	public class Image : GraphicsComponent
	{
		public GTexture Texture;

		public int Width
		{
			get { return Texture.Width; }
		}

		public int Height
		{
			get { return Texture.Height; }
		}

		public Image(GTexture texture)
		{
			Texture = texture;
		}

		public override void Draw()
		{
			if (Texture != null)
			{
				Texture.Draw(RenderPosition, Origin, Color, Scale, Rotation, Effects);
			}
		}

		public Image SetOrigin(float x, float y)
		{
			Origin.X = x;
			Origin.Y = y;
			return this;
		}

		public Image CenterOrigin()
		{
			return JustifyOrigin(0.5f, 0.5f);
		}

		public Image JustifyOrigin(Vector2 at)
		{
			return JustifyOrigin(at.X, at.Y);
		}

		public Image JustifyOrigin(float x, float y)
		{
			return SetOrigin(Width * x, Height * y);
		}

	}
}
