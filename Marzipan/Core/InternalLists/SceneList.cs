using System;
using System.Collections.Generic;

//TODO function to get a scene by name

namespace Marzipan.Core.InternalLists
{
	public class SceneList
	{
		private readonly List<Scene> scenes;

		private readonly HashSet<Scene> adding;
		private readonly HashSet<Scene> removing;

		public SceneList() {
			scenes = new List<Scene>();

			adding = new HashSet<Scene>();
			removing = new HashSet<Scene>();
		}

		public bool Add(Scene s) {
			if (scenes.Contains(s) || adding.Contains(s)) return false;
			adding.Add(s);
			return true;
		}

		public bool Remove(Scene s) {
			if (!scenes.Contains(s) || removing.Contains(s)) return false;
			removing.Add(s);
			return true;
		}

		//TODO functions to change the order of scenes (add before/after/front/back, move before/after, etc. Don't want to do active sorting and whatnot as there are usually only a few active scenes)

		public void UpdateLists() {
			if (adding.Count != 0) {
				foreach (Scene s in adding) {
					scenes.Add(s);
				}
				adding.Clear();
			}

			if (removing.Count != 0) {
				foreach (Scene s in removing) {
					scenes.Remove(s);
				}
				removing.Clear();
			}
		}

		public void Update() {
			UpdateLists();

			foreach (Scene s in scenes) {
				s.Update();
			}
		}

		public void Draw() {
			foreach (Scene s in scenes) {
				s.Draw();
			}
		}
	}
}
