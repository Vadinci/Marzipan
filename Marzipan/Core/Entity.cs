using System;
using System.Collections.Generic;

namespace Marzipan.Core
{
	public class Entity
	{
		//TODO is the seperate ComponentList of Monocle interesting to replicate?
		//Would allow things along the lines of entity.components.get<>() rather than entity.getComponent<>()
		public List<Component> components = new List<Component>();  //TODO should this be public?

		public List<String> tags = new List<string>();

		public bool active = true;
		public bool visible = true;

		//higher priority gets updated first
		//TODO priority should optional (can be toggled per scene). For some games, the, depth is stable enough. However, in games where depth constantly changes (e.g. with Z-sorting), the update
		//order can change per frame, and lead to tricky gameplay situations
		public float priority;
		//higher depth gets rendered first (so appears on the background)
		public float depth;

		private Transform _transform;
		public Transform transform { get => _transform; }

		public Entity() {
			_transform = new Transform();
		}

		//TODO check Monocle's 'awake' function. Also do similar things for when the scene awakes/sleeps?

		public void Added() {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				//TODO wrong function call
				components[ii].Added(this);
			}
		}

		public virtual void Update() {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].Update();
			}
		}

		public void Draw() {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].PreDraw();
			}

			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].Draw();
			}

			for (int ii = cc - 1; ii >= 0; ii--) {
				//TODO what if a new component is added here?
				components[ii].PostDraw();
			}
		}

		public void DrawDebug() {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].PreDraw();
			}

			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].DrawDebug();
			}

			for (int ii = cc - 1; ii >= 0; ii--) {
				//TODO what if a new component is added here?
				components[ii].PostDraw();
			}
		}

		public void Removed() {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				components[ii].Removed();
			}
		}

		public Component Add(Component component) {
			components.Add(component);
			component.Added(this);
			return component;
		}

		public T Add<T>(T component) where T : Component {
			components.Add(component);
			component.Added(this);
			return component;
		}

		public void Remove(Component component) {
			components.Remove(component);
		}

		public T Get<T>() where T : Component {
			int cc = components.Count;
			for (int ii = 0; ii < cc; ii++) {
				if (components[ii] is T) return components[ii] as T;
			}
			return null;
		}
	}
}
