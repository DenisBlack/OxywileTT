using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidPrefabContainer", menuName = "Data/AsteroidPrefabContainer")]
    public class AsteroidPrefabContainer : ScriptableObject
    {
        [SerializeField] private Asteroid[] _asteroids;
        public Asteroid[] Asteroids => _asteroids;
    }
}
