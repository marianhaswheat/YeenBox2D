using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeenBoxLib.Renderer;
using YeenBoxLib.YeenBox.Tiles;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace YeenBoxLib.YeenBox
{
    class YeenUtils
    {
        //Render tile function. This calls a draw elelemtns call for rendering a tile.
        public static void RenderTile(Camera camera, ITile tile)
        {
            //Create temporary matrix4f and give it the Camera's projection Matrix
            Matrix4 projection = camera.getProjectionMatrix();
            //Send the Camera projection Matrix too the shader!
            GL.UniformMatrix4(4, false, ref projection);
            //Make temporary matrix4f of the Camera
            Matrix4 camerapos = camera.getCameraMatrix();
            //Send the camera matrix to the GPU
            GL.UniformMatrix4(6, false, ref camerapos);
            //Send the tile positon to the GPU 
            GL.UniformMatrix4(5, false, ref tile.position);
            //Select the correct texture for rendering from GPU memory
            GL.BindTexture(TextureTarget.Texture2D, tile.TextureBind);
            //Then call the draw code now that all data is in place for the shaders
            GL.DrawElements(PrimitiveType.Triangles, Geometry.indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public static void RenderPlayer(Camera camera, Player.Player player)
        {
            //Create temporary matrix4f and give it the Camera's projection Matrix
            Matrix4 projection = camera.getProjectionMatrix();
            //Send the Camera projection Matrix too the shader!
            GL.UniformMatrix4(4, false, ref projection);
            //Make temporary matrix4f of the Camera
            Matrix4 camerapos = camera.getCameraMatrix();
            //Send the camera matrix to the GPU
            GL.UniformMatrix4(6, false, ref camerapos);
            //Send the tile positon to the GPU e
            GL.UniformMatrix4(5, false, ref player.position);
            //Select the correct texture for rendering from GPU memory
            GL.BindTexture(TextureTarget.Texture2D, player.TextureBind);
            //Then call the draw code now that all data is in place for the shaders
            GL.DrawElements(PrimitiveType.Triangles, Geometry.indices.Length, DrawElementsType.UnsignedInt, 0);
        }

    }
}
