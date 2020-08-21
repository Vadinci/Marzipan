using System;
using Marzipan.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marzipan.Components
{
	public class GraphicsComponent : Component
	{
		public Vector2 Position;
		public Vector2 Origin;
		public Vector2 Scale = Vector2.One;
		public float Rotation;
		public Color Color = Color.White;
		public SpriteEffects Effects = SpriteEffects.None;


		public GraphicsComponent()
		{

		}

		public Vector2 RenderPosition
		{
			get
				{
					return (Parent == null ? Vector2.Zero : Parent.Position) + Position;
				}

			set
				{
					Position = value - (Parent == null ? Vector2.Zero : Parent.Position);
				}
		}
	}
}
