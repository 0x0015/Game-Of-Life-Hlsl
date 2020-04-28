using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Life
{
    public class RenderLayer
    {
        public RenderTarget2D renderTarget;
        private Texture2D tex;
        public SpriteBatch spriteBatch;

        public virtual void Draw(SpriteBatch spriteBatch, float layerDepth)
        {
            spriteBatch.Draw(tex, new Rectangle(Camera.ScreenRect.X, Camera.ScreenRect.Y, Resolution.VirtualWidth, Resolution.VirtualHeight), new Rectangle(0, 0, renderTarget.Width, renderTarget.Height), Color.White, 0f, new Vector2(0,0), SpriteEffects.None, layerDepth);
        }
        public virtual void BeginLayerDraw()
        {
            if (spriteBatch == null)
            {
                spriteBatch = new SpriteBatch(Global.game.GraphicsDevice);
            }
            if (renderTarget == null)
            {
                renderTarget = new RenderTarget2D(Global.game.GraphicsDevice, Resolution.VirtualWidth, Resolution.VirtualHeight);
            }
            
            Global.game.GraphicsDevice.SetRenderTarget(renderTarget);
            Global.game.GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            
        }
        public virtual void EndLayerDraw()
        {
            spriteBatch.End();

            Global.game.GraphicsDevice.SetRenderTarget(null);

            tex = renderTarget;
            
        }

        public virtual void applyShader(Shader shader)
        {
            tex = shader.ApplyShader(tex);
        }


    }
}
