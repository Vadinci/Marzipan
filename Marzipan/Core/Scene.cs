using System;
using Marzipan.Core.InternalLists;

namespace Marzipan.Core
{
	public class Scene
	{
		public string name = "Scene";

		private EntityList _entities;
		public EntityList Entities {
			get => _entities;
		}

		public Scene() {
			_entities = new EntityList();
		}

		public virtual void Update() {
			_entities.Update();
		}

		public virtual void Draw() {
			_entities.Draw();
		}

		public virtual void DrawDebug() {
			_entities.DrawDebug();
		}

		public bool Add(Entity e) {
			return _entities.Add(e);
		}

		public bool Remove(Entity e) {
			return _entities.Remove(e);
		}
	}
}
