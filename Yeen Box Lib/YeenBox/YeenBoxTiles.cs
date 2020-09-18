using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Yeen_Box_Lib.Renderer;
using Yeen_Box_Lib.YeenBox.Tiles;
using Yeen_Box_Lib.YeenBox.World;

namespace Yeen_Box_Lib.YeenBox
{
    class YeenBoxTiles
    {
        public static ITile floor;

        public static Camera camera;

        public static IDimension Dimension;

        public static IWorld World;

        public static int[] TextureBinds;

        public static void initializeObjects()
        {
            Texture.GenerateTextureArray(1);
            Texture.genTexture(0, @"Bin/textures/TEXTURE.png");

            floor = new ITile(0);
            floor.setPosition(1, 1);

            Dimension = new IDimension(floor, 0.1f, new Vector3(0.0f, 0.0f, 0.0f));

            World = new IWorld(Dimension);

            camera = new Camera(Renderer.Renderer.width, Renderer.Renderer.height);

            camera.setCameraPosition(1, 1);

            World.GenerateWorld();
        }

        public static double xx = 0;

        public static void renderWorld()
        {
            xx += 0.01f;

            float xtrue = (float)Math.Sin(xx);
            float ytrue = (float)Math.Cos(xx);

            camera.setCameraPosition(xtrue, ytrue);

            Console.WriteLine(xx);

            World.RenderWorld(camera);
        }
    }
}
