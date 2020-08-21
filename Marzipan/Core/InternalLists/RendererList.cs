using System;
using System.Collections.Generic;
using Marzipan.Graphics;

namespace Marzipan.Core.InternalLists
{
	public class RendererList
	{
		private readonly List<Renderer> renderers;

		private readonly List<Renderer> adding;
		private readonly List<Renderer> removing;

		private readonly Scene scene;

		public RendererList(Scene scene)
		{
			renderers = new List<Renderer>();

			adding = new List<Renderer>();
			removing = new List<Renderer>();

			this.scene = scene;
		}


		internal void UpdateLists()
		{
			if (adding.Count > 0)
			{
				foreach (var renderer in adding)
					renderers.Add(renderer);
			}
			adding.Clear();
			if (removing.Count > 0)
			{
				foreach (var renderer in removing)
					renderers.Remove(renderer);
			}
			removing.Clear();
		}

		internal void Update()
		{
			UpdateLists();

			foreach (var renderer in renderers)
				renderer.Update(scene);
		}

		//TODO never called yet
		internal void BeforeRender()
		{
			for (int i = 0; i < renderers.Count; i++)
			{
				if (!renderers[i].Visible)
					continue;
				GraphicsUtils.Renderer = renderers[i];
				renderers[i].BeforeRender(scene);
			}
		}

		
		internal void Render()
		{
			for (int i = 0; i < renderers.Count; i++)
			{
				if (!renderers[i].Visible)
					continue;
				GraphicsUtils.Renderer = renderers[i];
				renderers[i].Render(scene);
			}
		}

		//TODO never called yet
		internal void AfterRender()
		{
			for (int i = 0; i < renderers.Count; i++)
			{
				if (!renderers[i].Visible)
					continue;
				GraphicsUtils.Renderer = renderers[i];
				renderers[i].AfterRender(scene);
			}
		}

		public void MoveToFront(Renderer renderer)
		{
			renderers.Remove(renderer);
			renderers.Add(renderer);
		}

		public void Add(Renderer renderer)
		{
			adding.Add(renderer);
		}

		public void Remove(Renderer renderer)
		{
			removing.Add(renderer);
		}

	}
}
