using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yeen_Box_Lib.Renderer;
using Yeen_Box_Lib.YeenBox.Tiles;

using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace Yeen_Box_Lib.YeenBox
{
    class YeenUtils
    {
        public static void RenderTile(Camera camera, ITile tile)
        {
            Matrix4 projection = camera.getProjectionMatrix();
            GL.UniformMatrix4(4, false, ref projection);
            Matrix4 camerapos = camera.getCameraMatrix();
            GL.UniformMatrix4(6, false, ref camerapos);
            GL.Uniform2(5, tile.position);
            GL.BindTexture(TextureTarget.Texture2D, tile.TextureBind);
            GL.DrawElements(PrimitiveType.Triangles, Geometry.indices.Length, DrawElementsType.UnsignedInt, 0);
        }

    }
}
