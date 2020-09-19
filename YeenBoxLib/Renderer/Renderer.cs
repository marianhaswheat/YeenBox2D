using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Yeen_Box.Renderer;

using Yeen_Box_Lib.YeenBox;

namespace Yeen_Box_Lib.Renderer
{
    class Renderer
    {
        public static int width = 1920;
        public static int height = 1080;

        public static int VertexBufferObject;
        public static int VertexArrayObject;

        public static int ElementBufferObject;

        public static ShaderSystem system = new ShaderSystem();

        public static int Shader;

        public static Matrix4 ProjectionMatrix;

        public static void CompileShaders()
        {
            Shader = system.compileShader(@"Bin/shaders/shader.vert", @"Bin/shaders/shader.frag");
        }

        public static void LoadRenderer()
        {
            CompileShaders();

            CreateProjectionMatrix(width, height);

            //VertexShader
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Geometry.vertices.Length * sizeof(float), Geometry.vertices, BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);
            // 2. copy our vertices array in a buffer for OpenGL to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Geometry.vertices.Length * sizeof(float), Geometry.vertices, BufferUsageHint.StaticDraw);
            // 3. then set our vertex attributes pointers
            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Geometry.indices.Length * sizeof(uint), Geometry.indices, BufferUsageHint.StaticDraw);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            system.Use(Shader);

            YeenBoxTiles.initializeObjects();

        }
        //The draw frame loop, rendering functions go here
        public static void DrawFrame()
        {
            system.Use(Shader);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            YeenBoxTiles.renderWorld();
            /*GL.UniformMatrix4(5, false, ref position);
            GL.BindTexture(TextureTarget.Texture2D, textureBind);
            GL.DrawElements(PrimitiveType.Triangles, Geometry.indices.Length, DrawElementsType.UnsignedInt, 0);*/
        }

        //Create Projection Matrix
        public static void CreateProjectionMatrix(int height, int width)
        {
            int xaspect = width / 100;
            int yaspect = (height) / 100;
            ProjectionMatrix = Matrix4.CreateOrthographic(xaspect, yaspect, 0.01f, 100f);
        }

        public static void DisposeRenderer()
        {
            //Unbind the vertex buffer array
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //Delete Vertex Buffer
            GL.DeleteBuffer(VertexBufferObject);
        }

    }

}
