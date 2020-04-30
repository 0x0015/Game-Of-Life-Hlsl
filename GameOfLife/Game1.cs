using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Life
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        

        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 screen;
        Texture2D screenTex;
        Shader life;

        int scale = 1;
        int speed = 1;
        int counter = 0;
        bool paused = false;

        public Game1() //This is the constructor, this function is called whenever the game class is created.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Resolution.Init(ref graphics);
            Resolution.SetVirtualResolution(1280, 720);
            Resolution.SetResolution(1280, 720, false);
            SDL2.SDL.SDL_ShowCursor(1);
        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            Camera.Initialize();
            Global.Initialize(this);
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            life = new Shader(Content, "Life");
            screenTex = TextureLoader.Load("map", Content);
            Resolution.SetResolution(screenTex.Width, screenTex.Height, false);
            Resolution.SetVirtualResolution(screenTex.Width, screenTex.Height);
            //Resolution.SetVirtualResolution(map.Width, map.Height);
        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            if (Input.KeyPressed(Keys.Escape))
            {
                this.Exit();
            }
            if (Input.KeyPressed(Keys.NumPad1))
            {
                scale = 1;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad2))
            {
                scale = 2;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad3))
            {
                scale = 3;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad4))
            {
                scale = 4;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad5))
            {
                scale = 5;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad6))
            {
                scale = 6;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad7))
            {
                scale = 7;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad8))
            {
                scale = 8;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.NumPad9))
            {
                scale = 9;
                Resolution.SetResolution(screenTex.Width * scale, screenTex.Height * scale, false);
                Resolution.SetVirtualResolution(screenTex.Width * scale, screenTex.Height * scale);
            }
            if (Input.KeyPressed(Keys.Space))
            {
                if (paused)
                {
                    paused = false;
                }
                else
                {
                    paused = true;
                }
            }
            //Console.WriteLine(Mouse.GetState().ScrollWheelValue);
            speed = (1 + (int)(Mouse.GetState().ScrollWheelValue / 800));
            base.Update(gameTime);
            
        }
        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            if(Resolution.VirtualHeight > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height && Resolution.VirtualWidth > GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
            {
                Resolution.SetResolution(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, false);
                Resolution.SetVirtualResolution(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (paused == false)
            {

                life.SetParam("screenPos", new Vector4(Camera.ScreenRect.X, Camera.ScreenRect.Y, screenTex.Width, screenTex.Height));
                if (speed >= 1)
                {
                    for (int i = 0; i < speed; i++)
                    {
                        screenTex = life.ApplyShader(screenTex);
                    }
                }
                else
                {
                    //Console.WriteLine(-speed + 1);
                    if(counter >= -speed + 1)
                    {
                        screenTex = life.ApplyShader(screenTex);
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null);
            spriteBatch.Draw(screenTex, new Rectangle(0,0,Resolution.VirtualWidth, Resolution.VirtualHeight), Color.White);
            spriteBatch.End();
            

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }

        

    }
    
}