using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Yeen_Box_Lib.Renderer;

namespace Yeen_Box_Lib.YeenBox.Tiles
{
    class ITile
    {
        //Location of the Tile in the world
        public Vector2 position;
        //The memory location on the GPU for the texture
        public int TextureBind;

        //Intiilizes a copy of the Tile and takes the index of where the texture is located at
        public ITile(int Index)
        {
            TextureBind = Texture.TextureBinds[Index];
        }

        //Return GPU memory address for the Tile Texture
        public int getTextureBind()
        {
            return TextureBind;
        }

        //Set the positon of the Tile
        public void setPosition(int x, int y)
        {
            position = new Vector2(x, y);
        }
    }
}
