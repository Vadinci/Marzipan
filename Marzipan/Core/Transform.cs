using System;
using Microsoft.Xna.Framework;

namespace Marzipan.Core
{
	public class Transform
	{
		private Vector2 _position;
		public Vector2 position { get => _position; }

		private Vector2 _scale;
		public Vector2 scale { get => _scale; }

		private float _rotation;
		public float rotation { get => _rotation; }

		public Transform(float x = 0, float y = 0) {
			_position = new Vector2(x, y);
			_scale = Vector2.One;
			_rotation = 0;
		}


		public void MoveBy(float dx, float dy) {
			_position.X += dx;
			_position.Y += dy;
		}

		public void MoveTo(float dx, float dy) {
			_position.X = dx;
			_position.Y = dy;
		}

		//TODO methods

	}
}
