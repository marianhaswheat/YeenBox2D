using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yeen_Box_Lib.Renderer
{
    public class Camera
    {
        private Matrix4 ProjectionMatrix;
        private Matrix4 CameraPosition;

        public Camera(int width, int height)
        {
            CreateProjectionMatrix(height, width);
            CameraPosition = Matrix4.CreateTranslation(1, 1, 1f);
        }
        
        public Matrix4 getProjectionMatrix()
        {
            return ProjectionMatrix;
        }

        public Matrix4 getCameraMatrix()
        {
            return CameraPosition;
        }

        public void moveCameraX(float speed)
        {
            CameraPosition *= Matrix4.CreateTranslation(speed, 0, 0);
        }

        public void moveCameraY(float speed)
        {
            CameraPosition *= Matrix4.CreateTranslation(0, speed, 0);
        }

        public void setCameraPosition(float x, float y)
        {
            CameraPosition = Matrix4.CreateTranslation(x, y, 1);
        }

        public void CreateProjectionMatrix(int height, int width)
        {
            float xaspect = width / 200;
            float yaspect = height / 200;
            ProjectionMatrix = Matrix4.CreateOrthographic(xaspect, yaspect, 0.01f, 100f);
        }
    }
}
