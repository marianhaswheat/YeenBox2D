using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Mathematics;

using OpenTK.Input;

using YeenBoxLib.Renderer;
using OpenTK.Windowing.GraphicsLibraryFramework;
using YeenBoxLib.YeenBox;

using OpenTK.Graphics.OpenGL4;

namespace YeenBoxLib
{
    internal class MainWindow : GameWindow
    {
        public MainWindow() : base(GameWindowSettings,
                               NativeWindowSettings)
        {

        }

        private static GameWindowSettings GameWindowSettings =
          new GameWindowSettings { RenderFrequency = 60.0f, UpdateFrequency = 60.0f };

        private static NativeWindowSettings NativeWindowSettings =
          new NativeWindowSettings
          {
              API = ContextAPI.OpenGL,
              APIVersion = new Version(4, 1),
              Size = new Vector2i(1920, 1080),
              Title = "Yeen Box!",
              Flags = ContextFlags.ForwardCompatible
          };

        protected override void OnLoad()
        {
            Renderer.Renderer.LoadRenderer();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            Renderer.Renderer.DrawFrame();
            SwapBuffers();
            base.OnUpdateFrame(args);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            var key = e.ScanCode;

            Console.WriteLine("User pressed " + e.Key);

            
            if (e.Key == Key.W)
            {
                YeenBoxTiles.Y += 1;
            }
            if (e.Key == Key.S)
            {
                YeenBoxTiles.Y -= 1;
            }
            if (e.Key == Key.A)
            {
                YeenBoxTiles.X -= 1;
            }
            if (e.Key == Key.D)
            {
                YeenBoxTiles.X += 1;
            }
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {

        }
        protected override void OnClosed()
        {
            Renderer.Renderer.DisposeRenderer();

            base.OnClosed();
        }

    }
}
