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
        //Location of the player in the world
        public Matrix4 position;
        //The memory location on the GPU for the texture
        public int TextureBind;

        public bool isLocal = false;

        //Intiilizes a copy of the Tile and takes the index of where the texture is located at
        public Player(int Index, bool isLocal)
        {
            TextureBind = Texture.TextureBinds[Index];
            this.isLocal = isLocal;
        }

        //Return GPU memory address for the Tile Texture
        public int getTextureBind()
        {
            return TextureBind;
        }

        public void Move(PlayerMovement mov)
        {
            if (mov == PlayerMovement.LEFT)
            {
                //position += new Vector2(-1, 0);
            }
            if (mov == PlayerMovement.RIGHT)
            {
                //position += new Vector2(-1, 0);
            }
            if (mov == PlayerMovement.UP)
            {
                //position += new Vector2(-1, 0);
            }
            if (mov == PlayerMovement.DOWN)
            {
                //position += new Vector2(-1, 0);
            }
        }

        //Set the positon of the Tile
        public void setPosition(int x, int y)
        {
            position = Matrix4.CreateTranslation(x, y, -5);
        }

        public void UpdateCamera(Camera camera)
        {
            //camera.setCameraPosition(position);
        }

    }
    enum PlayerMovement
    {
        LEFT = 0,
        RIGHT = 1,
        UP = 2,
        DOWN = 3
    }
}
