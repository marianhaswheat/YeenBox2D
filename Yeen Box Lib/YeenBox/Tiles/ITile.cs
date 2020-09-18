using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using Yeen_Box_Lib.Renderer;

namespace Yeen_Box_Lib.YeenBox.Tiles
{
    class ITile
    {
        public Vector2 position;
        public int TextureBind;

        public ITile(int Index)
        {
            TextureBind = Texture.TextureBinds[Index];
        }

        public int getTextureBind()
        {
            return TextureBind;
        }

        public void setPosition(int x, int y)
        {
            position = new Vector2(x, y);
        }
    }
}
