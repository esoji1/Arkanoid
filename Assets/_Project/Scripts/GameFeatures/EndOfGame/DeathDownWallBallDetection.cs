using _Project.GameFeatures.BallManagement;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.EndOfGame
{
    public class DeathDownWallBallDetection : MonoBehaviour
    {
        private EndOfGameManager _endOfGameManager;

        [Inject]
        public void Construct(EndOfGameManager endOfGameManager) => 
            _endOfGameManager = endOfGameManager;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ball _))
            {
                _endOfGameManager.GameOver();
            }
        }
    }
}