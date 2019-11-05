using System;
using System.Collections.Generic;

namespace Marzipan.Core.InternalLists
{
	public class EntityList
	{
		private List<Entity> _updateList;
		private List<Entity> _drawList;

		private HashSet<Entity> _entities;
		private HashSet<Entity> _adding;
		private HashSet<Entity> _removing;

		private bool _unsorted;
		private bool _activeSort;       //sort every frame, regardless of wether the lists have changed
		private bool _useDepthForUpdate;    //TODO

		public EntityList(bool activeSort_ = false, bool useDepthForUpdate_ = false) {
			_activeSort = activeSort_;
			_useDepthForUpdate = useDepthForUpdate_;

			_updateList = new List<Entity>();
			_drawList = new List<Entity>();

			_entities = new HashSet<Entity>();
			_adding = new HashSet<Entity>();
			_removing = new HashSet<Entity>();
		}

		public bool Add(Entity e) {
			//check for existence
			if (_entities.Contains(e) || _adding.Contains(e)) return false;
			_adding.Add(e);
			return true;
		}

		public bool Remove(Entity e) {
			if (!_entities.Contains(e) || _removing.Contains(e)) return false;
			_removing.Add(e);
			return true;
		}

		public int Count() {
			return _entities.Count;
		}

		public void UpdateLists() {
			if (_adding.Count > 0) {
				foreach (Entity e in _adding) {
					_updateList.Add(e);
					_drawList.Add(e);
				}
				_adding.Clear();

				_unsorted = true;
			}

			if (_removing.Count > 0) {
				foreach (Entity e in _removing) {
					_updateList.Remove(e);
					_drawList.Remove(e);
				}
				_removing.Clear();
			}
		}

		public void Sort() {
			//TODO sort update list
			//TODO sort draw list
			_unsorted = false;
		}

		public void Update() {
			UpdateLists();

			if (_activeSort || _unsorted) {
				Sort();
			}

			foreach (Entity e in _updateList) {
				e.Update();
			}
		}

		//TODO pass a draw context?
		public void Draw() {
			foreach (Entity e in _drawList) {
				e.Draw();
			}
		}

		public void DrawDebug() {
			foreach (Entity e in _drawList) {
				e.DrawDebug();
			}
		}
	}
}
