using System;

using Marzipan.Core;
using Marzipan.Core.InternalLists;

namespace Marzipan
{
	public static class MZP
	{
		private static Engine _engine;
		public static Engine Engine {
			get {
				if (_engine == null) _engine = new Engine();
				return _engine;
			}
		}

		private static Input _input;
		public static Input Input {
			get {
				if (_input == null) _input = new Input();
				return _input;
			}
		}

		public static SceneList Scenes {
			get {
				return Engine.scenes;
			}
		}

	}
}
