using UnityEngine;
using Zenject;

namespace Utils
{
    public class LevelBorders : IInitializable
    {
        private readonly Camera _camera;
        private float _screenWidth;
        private float _screenHeight;
        
        public LevelBorders(Camera camera)
        {
            _camera = camera;
        }

        public void Initialize()
        {
            CalculateScreenBounds();
        }

        private void CalculateScreenBounds()
        {
            var orthographicSize = _camera.orthographicSize;
            _screenWidth = orthographicSize * 2 * Screen.width / Screen.height;
            _screenHeight = orthographicSize * 2;
        }

        public float GetScreenWidth()
        {
            return _screenWidth;
        }

        public float GetScreenHeight()
        {
            return _screenHeight;
        }
    }
}