using System;
using Marzipan.Core.InternalLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marzipan.Core
{
	public class Scene
	{
		public string Name = "Scene";

		public Vector2 Offset = Vector2.Zero;

		public EntityList Entities {get; private set;}
		public RendererList Renderers {get; private set; }

		public Scene() {
			Entities = new EntityList();
			Renderers = new RendererList(this);
		}

		public virtual void Update() {
			Renderers.Update();
			Entities.Update();
		}

		public virtual void Draw() {
			Renderers.Render();
		}

		public bool Add(Entity e) {
			if (e.Scene != null) {
				//TODO log error
				return false;
			}
			e.Scene = this;
			return Entities.Add(e);
		}

		public bool Remove(Entity e) {
			if (e.Scene != this) {
				//TODO log error
				return false;
			}
			e.Scene = null;
			return Entities.Remove(e);
		}

		//TODO a bunch of clever ways to get entities
	}
}
