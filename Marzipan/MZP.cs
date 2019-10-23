using System;

using Marzipan.Core;

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
	}
}
