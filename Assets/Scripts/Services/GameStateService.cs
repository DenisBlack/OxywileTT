using UnityEngine;

namespace Services
{
    public class GameStateService
    {
        private GameState currentState = GameState.Game;

        public  GameState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        
        public  bool IsPaused()
        {
            return currentState == GameState.Pause;
        }
        
        public void ChangeState(GameState newState)
        {
            currentState = newState;
            Time.timeScale = (newState == GameState.Pause) ? 0f : 1f;
        }
    }
    
    public enum GameState
    {
        Game,
        Pause,
        Menu
    }

}