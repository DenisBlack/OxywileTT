using Inputs;
using Services;
using UnityEngine;
using Utils;
using Zenject;

namespace PlayerComponents
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private SpriteRenderer _characterSR;

        private LevelBorders _levelBorders;
        private float _leftLimit;
        private float _rightLimit;
        private IInputService _inputService;
        private GameStateService _gameStateService;

        [Inject]
        public void Construct(LevelBorders levelBorders, IInputService inputService, GameStateService gameStateService)
        {
            _levelBorders = levelBorders;
            _inputService = inputService;
            _gameStateService = gameStateService;
        }

        private void Start()
        {
            var screenWidth = _levelBorders.GetScreenWidth();
            var spriteWidth = _characterSR.bounds.size.x;

            _leftLimit = -screenWidth / 2 + spriteWidth / 2;
            _rightLimit = screenWidth / 2 - spriteWidth / 2;
        }

        void Update()
        {
            if(_gameStateService.IsPaused())
                return;

            if (_inputService.Pressed())
            {
                if (_inputService.GetInputDirection() == InputDirection.Left)
                    transform.Translate(Vector2.left * _speed * Time.deltaTime);
                else if (_inputService.GetInputDirection() == InputDirection.Right)
                    transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
            
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, _leftLimit, _rightLimit);
            transform.position = clampedPosition;
        }
    }

}