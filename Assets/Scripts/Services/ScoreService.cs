using System;

namespace Services
{
    public class ScoreService
    {
        private int _score;
        public int Score => _score;

        public event Action<int> ScoreChanged; 
  
        public void AddScore()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
