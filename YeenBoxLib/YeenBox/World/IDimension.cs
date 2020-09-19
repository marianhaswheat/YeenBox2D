using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Mathematics;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using Yeen_Box_Lib.YeenBox.Tiles;

namespace Yeen_Box_Lib.YeenBox.World
{
    class IDimension
    {
        public Vector3 AmbientColor;
        public float AmbientStrength;

        public ITile BaseFloor;

        public IDimension(ITile BaseFloor, float AmbientStrength, Vector3 AmbientColor)
        {
            this.BaseFloor = BaseFloor;
            this.AmbientColor = AmbientColor;
            this.AmbientStrength = AmbientStrength;
        }

        public void RenderDimension()
        {
            GL.Uniform1(6, AmbientStrength);
            GL.Uniform3(7, ref AmbientColor);
        }
    }
}
