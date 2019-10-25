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

		public Entity() {

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

		public void Add(Component component) {
			components.Add(component);
			component.Added(this);
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
