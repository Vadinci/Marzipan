using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Marzipan.Core
{
	public class Entity
	{
		//TODO is the seperate ComponentList of Monocle interesting to replicate?
		//Would allow things along the lines of entity.components.get<>() rather than entity.getComponent<>()
		public List<Component> Components = new List<Component>();  

		public List<String> Tags = new List<string>();

		public bool Active = true;
		public bool Visible = true;

		//higher priority gets updated first
		//TODO priority should optional (can be toggled per scene). For some games, the, depth is stable enough. However, in games where depth constantly changes (e.g. with Z-sorting), the update
		//order can change per frame, and lead to tricky gameplay situations
		public float Priority;
		//higher depth gets rendered first (so appears on the background)
		public float Depth;

		public Vector2 Position;

		
		public Scene Scene { get; internal set; }

		public Entity() {
			
		}

		//TODO check Monocle's 'awake' function. Also do similar things for when the scene awakes/sleeps?

		public void Added() {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				//TODO wrong function call
				Components[ii].Added(this);
			}
		}

		public virtual void Update() {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				Components[ii].Update();
			}
		}

		public void Draw() {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				Components[ii].PreDraw();
			}

			for (int ii = 0; ii < cc; ii++) {
				Components[ii].Draw();
			}

			for (int ii = cc - 1; ii >= 0; ii--) {
				Components[ii].PostDraw();
			}
		}

		public void DrawDebug() {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				Components[ii].PreDraw();
			}

			for (int ii = 0; ii < cc; ii++) {
				Components[ii].DrawDebug();
			}

			for (int ii = cc - 1; ii >= 0; ii--) {
				Components[ii].PostDraw();
			}
		}

		public void Removed() {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				//TODO what if a new component is added here?
				Components[ii].Removed();
			}
		}

		public Component Add(Component component) {
			Components.Add(component);
			component.Added(this);
			return component;
		}

		public T Add<T>(T component) where T : Component {
			Components.Add(component);
			component.Added(this);
			return component;
		}

		public T Add<T>() where T : Component, new() {
			T component = new T();
			Components.Add(component);
			component.Added(this);
			return component;
		}

		public void Remove(Component component) {
			Components.Remove(component);
		}

		public T Get<T>() where T : Component {
			int cc = Components.Count;
			for (int ii = 0; ii < cc; ii++) {
				if (Components[ii] is T) return Components[ii] as T;
			}
			return null;
		}
	}
}
