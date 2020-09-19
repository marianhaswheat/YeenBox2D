using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

using Yeen_Box.Renderer;

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
              Title = "Yeen Box!"
          };

        protected override void OnLoad()
        {
            Yeen_Box_Lib.Renderer.Renderer.LoadRenderer();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            Yeen_Box_Lib.Renderer.Renderer.DrawFrame();
            SwapBuffers();
            base.OnUpdateFrame(args);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {

        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {

        }
    }
}
