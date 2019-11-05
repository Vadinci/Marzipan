using System;
using System.Collections.Generic;

namespace Marzipan.Core.InternalLists
{
	public class SceneList
	{
		public List<Scene> _scenes;

		public HashSet<Scene> _adding;
		public HashSet<Scene> _removing;

		public SceneList() {
			_scenes = new List<Scene>();

			_adding = new HashSet<Scene>();
			_removing = new HashSet<Scene>();
		}

		public bool Add(Scene s) {
			if (_scenes.Contains(s) || _adding.Contains(s)) return false;
			_adding.Add(s);
			return true;
		}

		public bool Remove(Scene s) {
			if (!_scenes.Contains(s) || _removing.Contains(s)) return false;
			_removing.Add(s);
			return true;
		}

		//TODO functions to change the order of scenes (add before/after/front/back, move before/after, etc. Don't want to do active sorting and whatnot as there are usually only a few active scenes)

		public void UpdateLists() {
			if (_adding.Count != 0) {
				foreach (Scene s in _adding) {
					_scenes.Add(s);
				}
				_adding.Clear();
			}

			if (_removing.Count != 0) {
				foreach (Scene s in _removing) {
					_scenes.Remove(s);
				}
				_removing.Clear();
			}
		}

		public void Update() {
			UpdateLists();

			foreach (Scene s in _scenes) {
				s.Update();
			}
		}

		public void Draw() {
			foreach (Scene s in _scenes) {
				s.Draw();
			}
		}

		public void DrawDebug() {
			foreach (Scene s in _scenes) {
				s.DrawDebug();
			}
		}
	}
}
