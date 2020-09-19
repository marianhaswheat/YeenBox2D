using OpenTK.Core;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yeen_Box_Lib.Renderer
{
    public class Camera
    {
        /*
         * This class is the camera object for the game. It is refrenced throughout rendering.
         * You must have a camera object before rendering.
         * 
         * Coded by MarianHasWheat
         * 
         */

        //Creates projection matrix.
        private Matrix4 ProjectionMatrix;
        //Creates another matrix that will be the camera.
        private Matrix4 CameraPosition;

        //Initialize the camera object by taking the width and the height of the window.
        public Camera(int width, int height)
        {
            //Create the projection Matrix and send the width and height to do it.
            CreateProjectionMatrix(height, width);
            //Set the camera position too a default value.
            CameraPosition = Matrix4.CreateTranslation(1, 1, 1f);
        }
        
        //Returns the projection matrix
        public Matrix4 getProjectionMatrix()
        {

            return ProjectionMatrix;
        }

        //Returns the camera matrix
        public Matrix4 getCameraMatrix()
        {
            return CameraPosition;
        }

        //Move the camera by a speed value in the x position.
        public void moveCameraX(float speed)
        {
            CameraPosition *= Matrix4.CreateTranslation(speed, 0, 0);
        }

        //Move the camera by a speed value in the y position.
        public void moveCameraY(float speed)
        {
            CameraPosition *= Matrix4.CreateTranslation(0, speed, 0);
        }

        //Set camera position to a specif 2D coordinate.
        public void setCameraPosition(float x, float y)
        {
            CameraPosition = Matrix4.CreateTranslation(x, y, 1);
        }

        //Create the projection Matrix
        public void CreateProjectionMatrix(int height, int width)
        {
            //Generate an x aspect ratio of 1 hundred
            float xaspect = width / 200;
            //Generate an y aspect ratio of 1 hundred
            float yaspect = height / 200;

            ProjectionMatrix = Matrix4.CreateOrthographic(xaspect, yaspect, 0.01f, 100f);
        }
    }
}
