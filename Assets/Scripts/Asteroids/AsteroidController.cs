using System.Collections;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 1.5f;
        [SerializeField] private float _spawnYOffset;
    
        private float _screenWidth;
        private float _screenHeight;
        private float _spawnY;
    
        private AsteroidFactory _asteroidFactory;
        private LevelBorders _levelBorders;
        
        [Inject]
        public void Construct(AsteroidFactory asteroidFactory, LevelBorders levelBorders)
        {
            _asteroidFactory = asteroidFactory;
            _levelBorders = levelBorders;
        }

        void Start()
        {
            _screenWidth = _levelBorders.GetScreenWidth();
            _screenHeight = _levelBorders.GetScreenHeight();
            _spawnY = _screenHeight / 2;
            
            StartCoroutine(SpawnCoroutine());
        }
        
        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(_spawnInterval);
            }
        }

        void SpawnAsteroid()
        {
            float spawnX = Random.Range(-_screenWidth / 2, _screenWidth / 2);
            Vector3 spawnPosition = new Vector3(spawnX, _spawnY + _spawnYOffset, 0f);

            _asteroidFactory.Create(spawnPosition);
        }
    }
}
