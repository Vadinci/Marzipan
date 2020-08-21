using System;
namespace Marzipan.Core
{
	public abstract class Component
	{
		public Entity Parent { get; private set; }

		public Component()
		{
			
		}

		public virtual void Added(Entity parent)
		{
			Parent = parent;
		}

		public virtual void Update()
		{
			//OVERRIDE this
		}

		public virtual void PreDraw()
		{
			//OVERRIDE this
		}

		public virtual void Draw()
		{
			//OVERRIDE this
		}

		public virtual void PostDraw()
		{
			//OVERRIDE this
		}

		public virtual void DrawDebug()
		{
			//OVERRIDE this
		}

		public virtual void Removed()
		{
			//OVERRIDE this
		}
	}
}
