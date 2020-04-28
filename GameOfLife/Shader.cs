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
    public class Shader
    {
        public RenderTarget2D renderTarget;
        public SpriteBatch spriteBatch;
        Effect effect;
        Texture2D texture;
        public Shader()
        {

        }

        public Shader(ContentManager content, string name)
        {
            effect = content.Load<Effect>(name);
        }


        public virtual Texture2D ApplyShader(Texture2D image)
        {
            
            if (spriteBatch == null)
            {
                spriteBatch = new SpriteBatch(Global.game.GraphicsDevice);
            }
            if (renderTarget == null)
            {
                renderTarget = new RenderTarget2D(Global.game.GraphicsDevice, image.Width, image.Height);
            }
            Global.game.GraphicsDevice.SetRenderTarget(renderTarget);

            Global.game.GraphicsDevice.Clear(Color.Transparent);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            if (effect != null)
            {
                effect.CurrentTechnique.Passes[0].Apply();
            }

            spriteBatch.Draw(image, new Rectangle(0, 0, image.Width, image.Height), Color.White);

            spriteBatch.End();

            Global.game.GraphicsDevice.SetRenderTarget(null);
            if (texture == null)
            {
                texture = new Texture2D(Global.game.GraphicsDevice, image.Width, image.Height);
            }
            Color[] color = new Color[image.Width * image.Height];
            renderTarget.GetData(color);
            texture.SetData(color);
            return (texture);
        }

        public virtual void SetEffect(Effect ieffect)
        {
            effect = ieffect;
        }

        public virtual void LoadEffect(ContentManager content, string name)
        {
            effect = content.Load<Effect>(name);
        }

        public virtual void SetParam(string param, Vector2 value)
        {
            if (effect != null)
            {
                effect.Parameters[param].SetValue(value);
            }
        }

        public virtual void SetParam(string param, Vector4 value)
        {
            if (effect != null)
            {
                effect.Parameters[param].SetValue(value);
            }
        }

    }
}
