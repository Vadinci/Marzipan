using System;
using Marzipan.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Marzipan.Graphics.Renderers
{
	public class BasicRenderer : Renderer
	{

        public BlendState BlendState;
        public SamplerState SamplerState;
        public Effect Effect;
        public Camera Camera;

        public BasicRenderer() {
            BlendState = BlendState.AlphaBlend;
            SamplerState = SamplerState.LinearClamp;
            Camera = new Camera();
        }

        public override void Update(Scene scene)
        {

        }

        public override void BeforeRender(Scene scene)
        {
            
        }

        public override void Render(Scene scene)
        {
            GraphicsUtils.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState, SamplerState, DepthStencilState.None, RasterizerState.CullNone, Effect, Camera.Matrix * Engine.ScreenMatrix);

            scene.Entities.Draw();
            /*if (Engine.Commands.Open)
                scene.Entities.DrawDebug();*/

            GraphicsUtils.SpriteBatch.End();
        }

        public override void AfterRender(Scene scene)
        {

        }
    }
}
