using System;

namespace _Project.GameFeatures.EndOfGame
{
    public class EndOfGameManager
    {
        public event Action OnVictory;
        public event Action OnGameOver;

        private bool _isVictory;
        
        public void Victory()
        {
            _isVictory = true;
            OnVictory?.Invoke();
        }

        public void GameOver()
        {
            if (_isVictory)
            {
                return;
            }
            
            OnGameOver?.Invoke();
        }
    }
}