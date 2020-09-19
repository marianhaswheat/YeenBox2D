using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeenBoxLib.Renderer
{
    class Geometry
    {
        //DATA

        public static float[] vertices =
        {
            //Position          Texture coordinates
             0.5f,  0.5f, 0.1f, 1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.1f, 1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.1f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.1f, 0.0f, 1.0f  // top left
        };

        public static uint[] indices = {  // note that we start from 0!
            0, 1, 3,   // first triangle
            1, 2, 3
        };

        public static float[] texCoords = {
            0.0f, 0.0f,  // lower-left corner  
            1.0f, 0.0f,  // lower-right corner
            0.0f, 1.0f,   // top-center corner
            1.0f, 1.0f
        };
    }
}
