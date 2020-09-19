using System;
using System.Collections.Generic;
using System.Text;

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

using YeenBoxLib.Renderer;

namespace YeenBoxLib.YeenBox.Player
{
    class Player
    {
        //Location of the Tile in the world
        public Vector2 position;
        //The memory location on the GPU for the texture
        public int TextureBind;

        //Intiilizes a copy of the Tile and takes the index of where the texture is located at
        public Player(int Index, bool isLocal)
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
