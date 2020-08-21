using System;
using System.IO;
using Marzipan.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marzipan.Graphics
{
	public class GTexture
	{
		public Texture2D Texture { get; private set; }
		public Rectangle ClipRect { get; private set; }

		public int Width { get; private set; }
		public int Height { get; private set; }

		public Vector2 Center { get; private set; }

		public float LeftUV { get; private set; }
		public float RightUV { get; private set; }
		public float TopUV { get; private set; }
		public float BottomUV { get; private set; }

		#region constructors

		static public GTexture FromFile(string filename)
		{
			var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			var texture = Texture2D.FromStream(Engine.Instance.GraphicsDevice, fileStream);
			fileStream.Close();

			return new GTexture(texture);
		}

		public GTexture(Texture2D texture)
		{
			Texture = texture;
			ClipRect = new Rectangle(0, 0, texture.Width, texture.Height);

			Width = ClipRect.Width;
			Height = ClipRect.Height;

			SetUtil();
		}

		public GTexture(Texture2D texture, int x, int y, int width, int height)
		{
			Texture = texture;
			ClipRect = new Rectangle(x, y, width, height);
			Width = ClipRect.Width;
			Height = ClipRect.Height;

			SetUtil();
		}

		public GTexture(Texture2D texture, Rectangle clipRect)
			: this(texture, clipRect.X, clipRect.Y, clipRect.Width, clipRect.Height)
		{ }

		public GTexture(GTexture parent, int x, int y, int width, int height)
			: this(parent.Texture, x, y, width, height)
		{ }

		public GTexture(GTexture parent, Rectangle clipRect)
			: this(parent.Texture, clipRect)
		{ }

		private void SetUtil()
		{
			Center = new Vector2(Width, Height) * 0.5f;
			LeftUV = ClipRect.Left / (float)Texture.Width;
			RightUV = ClipRect.Right / (float)Texture.Width;
			TopUV = ClipRect.Top / (float)Texture.Height;
			BottomUV = ClipRect.Bottom / (float)Texture.Height;
		}

		//TODO get subtextures of current texture

		#endregion

		public Rectangle GetRelativeRect(Rectangle rect)
		{
			return GetRelativeRect(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public Rectangle GetRelativeRect(int x, int y, int width, int height)
		{
			int atX = (int)(ClipRect.X + x);
			int atY = (int)(ClipRect.Y + y);

			int rX = (int)MathHelper.Clamp(atX, ClipRect.Left, ClipRect.Right);
			int rY = (int)MathHelper.Clamp(atY, ClipRect.Top, ClipRect.Bottom);
			int rW = Math.Max(0, Math.Min(atX + width, ClipRect.Right) - rX);
			int rH = Math.Max(0, Math.Min(atY + height, ClipRect.Bottom) - rY);

			return new Rectangle(rX, rY, rW, rH);
		}

		#region drawing

		public void Draw(Vector2 position)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, 0, origin, 1f, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, float scale)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, 0, origin, scale, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, float scale, float rotation)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, rotation, origin, scale, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, float scale, float rotation, SpriteEffects flip)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, rotation, origin, scale, flip, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, Vector2 scale)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, 0, origin, scale, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, rotation, origin, scale, SpriteEffects.None, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, SpriteEffects effects)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, ClipRect, color, rotation, origin, scale, effects, 0);
		}

		public void Draw(Vector2 position, Vector2 origin, Color color, Vector2 scale, float rotation, Rectangle clip)
		{
			GraphicsUtils.SpriteBatch.Draw(Texture, position, GetRelativeRect(clip), color, rotation, origin, scale, SpriteEffects.None, 0);
		}

		#endregion
	}
}
