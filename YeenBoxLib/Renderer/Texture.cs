using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

using OpenTK.Graphics.OpenGL4;


namespace YeenBoxLib.Renderer
{
    class Texture
    {
        public static int[] TextureBinds;

        public static void GenerateTextureArray(int amount)
        {
            TextureBinds = new int[amount];
        }

        public static void genTexture(int index, string TexturePath)
        {
            Bitmap image = new Bitmap(TexturePath);
            int Handle;
            //Create The TExture ID and store it into the handler
            Handle = GL.GenTexture();
            //Bind the texture for use!
            GL.BindTexture(TextureTarget.Texture2D, Handle);

            //Set some paremters to those!
            //Repeat texture parameter
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            //Nearest neighbor parameter
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            //Start storing bitmap data into a BitmapData type
            System.Drawing.Imaging.BitmapData data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
            System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, (OpenTK.Graphics.OpenGL4.PixelFormat)PixelInternalFormat.Rgba, PixelType.UnsignedByte, data.Scan0);
            image.UnlockBits(data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            TextureBinds[index] = Handle;
        }
    }
}
