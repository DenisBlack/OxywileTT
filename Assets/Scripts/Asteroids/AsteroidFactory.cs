using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidFactory : IInitializable
    {
        [Inject] private DiContainer _diContainer;

        private readonly AsteroidPrefabContainer _asteroidPrefabContainer;
        private readonly List<Asteroid> _asteroidPool = new List<Asteroid>();
        private readonly int _poolSize = 10;

        private readonly Vector3 _defaultPos;

        public AsteroidFactory(AsteroidPrefabContainer asteroidPrefabContainer)
        {
            _asteroidPrefabContainer = asteroidPrefabContainer;
        }

        public void Initialize()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var randomPrefab = _asteroidPrefabContainer.Asteroids[Random.Range(0, _asteroidPrefabContainer.Asteroids.Length)];
                Asteroid asteroid = _diContainer.InstantiatePrefabForComponent<Asteroid>(randomPrefab, Vector3.zero, Quaternion.identity, null);
                _asteroidPool.Add(asteroid);
                asteroid.Initialize(ReturnAsteroidToPool);
                ReturnAsteroidToPool(asteroid);
            }
        }

        public Asteroid Create(Vector3 pos)
        {
            Asteroid asteroid = null;
        
            for (int i = 0; i < _asteroidPool.Count; i++)
            {
                if (!_asteroidPool[i].gameObject.activeInHierarchy)
                {
                    asteroid = _asteroidPool[i];
                }
            }

            if (asteroid == null)
            {
                var randomPrefab = _asteroidPrefabContainer.Asteroids[Random.Range(0, _asteroidPrefabContainer.Asteroids.Length)];
                asteroid = _diContainer.InstantiatePrefabForComponent<Asteroid>(randomPrefab);
                _asteroidPool.Add(asteroid);
            }

            asteroid.transform.position = pos;
            asteroid.gameObject.SetActive(true);
            return asteroid;
        }

        private void ReturnAsteroidToPool(Asteroid asteroid)
        {
            asteroid.gameObject.SetActive(false);
            asteroid.transform.position = _defaultPos;
        }
    }
}
