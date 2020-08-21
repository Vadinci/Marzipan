using System;
using System.Collections.Generic;

namespace Marzipan.Core.InternalLists
{
	public class EntityList
	{
        private readonly List<Entity> updateList;
		private readonly List<Entity> drawList;

		private readonly HashSet<Entity> entities;
		private readonly HashSet<Entity> adding;
		private readonly HashSet<Entity> removing;

		private bool unsorted;
		private readonly bool activeSort;       //sort every frame, regardless of wether the lists have changed
        private readonly bool useDepthForUpdate;    //TODO

        public EntityList(bool activeSort = false, bool useDepthForUpdate = false) {
			this.activeSort = activeSort;
			this.useDepthForUpdate = useDepthForUpdate;

			updateList = new List<Entity>();
			drawList = new List<Entity>();

			entities = new HashSet<Entity>();
			adding = new HashSet<Entity>();
			removing = new HashSet<Entity>();
		}

		public bool Add(Entity e) {
			//check for existence
			if (entities.Contains(e) || adding.Contains(e)) return false;
			adding.Add(e);
			return true;
		}

		public bool Remove(Entity e) {
			if (!entities.Contains(e) || removing.Contains(e)) return false;
			removing.Add(e);
			return true;
		}

		public int Count() {
			return entities.Count;
		}

		public void UpdateLists() {
			if (adding.Count > 0) {
				foreach (Entity e in adding) {
					updateList.Add(e);
					drawList.Add(e);
				}
				adding.Clear();

				unsorted = true;
			}

			if (removing.Count > 0) {
				foreach (Entity e in removing) {
					updateList.Remove(e);
					drawList.Remove(e);
				}
				removing.Clear();
			}
		}

		public void Sort() {
			//TODO sort update list
			//TODO sort draw list
			unsorted = false;
		}

		public void Update() {
			UpdateLists();

			foreach (Entity e in updateList) {
				e.Update();
			}

			if (activeSort || unsorted)
			{
				Sort();
			}
		}

		public void Draw() {
			foreach (Entity e in drawList) {
				e.Draw();
			}
		}

		public void DrawDebug() {
			foreach (Entity e in drawList) {
				e.DrawDebug();
			}
		}
	}
}
