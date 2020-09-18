using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using Yeen_Box.Renderer;
using Yeen_Box_Lib.Renderer;
using Yeen_Box_Lib.YeenBox;

namespace Yeen_Box_Lib
{
    public class YannieYeen : GameWindow
    {
        //LOGIC
        protected override void OnLoad(EventArgs e)
        {
            Renderer.Renderer.LoadRenderer();
            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            Renderer.Renderer.DisposeRenderer();
            base.OnUnload(e);
        }

        //Constructor of this class it sets the width, height, and title of the window
        public YannieYeen(int width, int height, string title)
        {
            //Set game window title to title
            this.Title = title;
            //Set the window width to width input of constructor
            this.Width = width;
            //Set the window hieght to hieght input of constructor
            this.Height = height;

            Renderer.Renderer.width = width;
            Renderer.Renderer.height = height;
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        //Update the rendering context when the window is is resized.
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            YeenBoxTiles.camera.CreateProjectionMatrix(Height, Width);
            base.OnResize(e);
        }

        //When the the game renders frames it hsould do the code listed below
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Renderer.Renderer.DrawFrame();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
