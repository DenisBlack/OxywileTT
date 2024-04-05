using UnityEngine;
using Utils;
using Zenject;

namespace Asteroids
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class AsteroidScreenBoundary : MonoBehaviour
    {
        [SerializeField] private float _posYOffset;
    
        private LevelBorders _levelBorders;

        [Inject]
        public void Construct(LevelBorders levelBorders)
        {
            _levelBorders = levelBorders;
        }
    
        void Start()
        {
            float screenWidth = _levelBorders.GetScreenWidth();
        
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = new Vector2(screenWidth, 1f);
        
            Vector2 newPosition = new Vector2(0f, -Camera.main.orthographicSize + _posYOffset);
            transform.position = newPosition;
        }
    }
}
