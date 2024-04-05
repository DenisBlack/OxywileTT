using System;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private const string PlayerTag = "Player";
        private const string ScreenBoundaryTag = "ScreenBoundary";
        
        private Action<Asteroid> ReleaseAction;

        public void Initialize(Action<Asteroid> returnBulletToPool)
        {
            ReleaseAction = returnBulletToPool;
        }
    
        void Update()
        {
            transform.Translate(Vector2.down  * _moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals(PlayerTag) || other.tag.Equals(ScreenBoundaryTag))
            {
                ReleaseAction?.Invoke(this);
            }
        }
    }
}
