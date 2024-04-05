using System;
using Services;
using UnityEngine;
using Zenject;

namespace PlayerComponents
{
    public class Player : MonoBehaviour
    {
        private ScoreService _scoreService;
        private PlayerAnimator _playerAnimator;
        private const string AsteroidTag = "Asteroid";
        
        [Inject]
        public void Construct(ScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Awake()
        {
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals(AsteroidTag))
            {
                _scoreService.AddScore();
                _playerAnimator.PlayDamageAnimation();
            }
        }
    }
}