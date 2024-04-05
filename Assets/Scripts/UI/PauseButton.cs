using System;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private bool _isResumeButton;
        
        private Button _button;
        private GameStateService _gameStateService;

        [Inject]
        public void Construct(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Call);
        }

        private void Call()
        {
            _gameStateService.ChangeState(_isResumeButton ? GameState.Game : GameState.Pause);
        }
    }
}