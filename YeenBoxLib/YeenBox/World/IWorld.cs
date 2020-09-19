using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yeen_Box_Lib.Renderer;
using Yeen_Box_Lib.YeenBox.Tiles;



namespace Yeen_Box_Lib.YeenBox.World
{
    class IWorld
    {
        public IDimension Dimension;

        public ITile[,] world_data;

        public void GenerateWorld()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    world_data[x, y] = new ITile(0);
                    world_data[x, y].setPosition(x, y);
                }
            }
        }
        

        public IWorld(IDimension Dimension)
        {
            world_data = new ITile[10,10];
            this.Dimension = Dimension;
        }

        public void RenderWorld(Camera camera)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    YeenUtils.RenderTile(camera, world_data[x,y]);
                }
            }
        }
    }
}