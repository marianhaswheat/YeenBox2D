using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YeenBoxLib.Renderer;
using YeenBoxLib.YeenBox.Tiles;
using YeenBoxLib.YeenBox.World;

using OpenTK.Mathematics;
using Microsoft.VisualBasic.CompilerServices;

namespace YeenBoxLib.YeenBox
{
    class YeenBoxTiles
    {
        //Hello.
        
        public static ITile floor;

        public static Camera camera;

        public static int X = -1;
        public static int Y = 0;

        public static IDimension Dimension;

        public static IWorld World;

        public static Matrix4 world = Matrix4.Identity;

        public static float[] Lights;

        public static Player.Player player;

        public static int[] TextureBinds;

        public static void initializeObjects()
        {
            Texture.GenerateTextureArray(2);
            Texture.genTexture(0, @"Bin/textures/TEXTURE.png");
            Texture.genTexture(1, @"Bin/textures/player.png");

            Lights = new float[12]
            {
                1.0f, 1.0f, 0.5f,
                9.0f, 1.0f, 0.5f,
                1.0f, 9.0f, 0.5f,
                9.0f, 9.0f, 0.5f
            };

            floor = new ITile(0);
            floor.setPosition(1, 1);

            Dimension = new IDimension(floor, 0.1f, new Vector3(0.0f, 0.0f, 0.0f));

            player = new Player.Player(1, true);

            World = new IWorld(Dimension);

            camera = new Camera(Renderer.Renderer.width, Renderer.Renderer.height);

            

            camera.setCameraPosition(1, 1);

            World.GenerateWorld();

            player.setPosition(-1, -1);
        }

        public static double xx = 0;

        //Update game logic!

        public static void UpdateWorld()
        {

        }


        //Rendering and calling upon render functiosn will occur here!
        public static void renderWorld()
        {
            player.setPosition(X, Y);
            camera.setCameraPosition(-X, -Y);

            GL.Uniform3(10, 12, Lights);
            GL.Uniform1(9, 4);

            xx += 0.01f;

            float xtrue = (float)Math.Sin(xx);
            float ytrue = (float)Math.Cos(xx);

            
            World.RenderWorld(camera);
            YeenUtils.RenderPlayer(camera, player);
        }
    }
}
