using System;
using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private string _scoreFormat = "Hits: {0}";
        private TMP_Text _scoreTMP;
        private ScoreService _scoreService;
        
        [Inject]
        public void Construct(ScoreService scoreService)
        {
            _scoreService = scoreService;
            _scoreService.ScoreChanged += ScoreServiceOnScoreChanged;
        }

        private void Awake()
        {
            _scoreTMP = GetComponent<TMP_Text>();
        }

        private void UpdateText(int value)
        {
            _scoreTMP.text = String.Format(_scoreFormat, value);
        }

        private void ScoreServiceOnScoreChanged(int value)
        {
            UpdateText(value);
        }

        private void OnDestroy()
        {
            _scoreService.ScoreChanged += ScoreServiceOnScoreChanged;
        }
    }
}