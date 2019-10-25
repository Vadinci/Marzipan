using System;
namespace Marzipan.Core
{
	public class Component
	{
		public Entity entity { get; private set; }

		public Component() {

		}

		public virtual void Added(Entity entity_) {
			entity = entity_;
		}

		public virtual void Update() {
			//OVERRIDE this
		}

		public virtual void PreDraw() {
			//OVERRIDE this
		}

		public virtual void Draw() {
			//OVERRIDE this
		}

		public virtual void PostDraw() {
			//OVERRIDE this
		}

		public virtual void DrawDebug() {
			//OVERRIDE this
		}

		public virtual void Removed() {
			//OVERRIDE this
		}
	}
}
