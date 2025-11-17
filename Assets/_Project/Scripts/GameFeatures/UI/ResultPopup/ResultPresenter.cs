using System;
using _Project.Core.Services;
using _Project.GameFeatures.EndOfGame;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.GameFeatures.UI.ResultPopup
{
    public class ResultPresenter : IInitializable, IDisposable
    {
        private readonly EndOfGameManager _endOfGameManager;
        private readonly ResultPopup _resultPopup;
        private readonly PointsService _pointsService;

        public ResultPresenter(EndOfGameManager endOfGameManager, ResultPopup resultPopup,
            PointsService pointsService)
        {
            _endOfGameManager = endOfGameManager;
            _resultPopup = resultPopup;
            _pointsService = pointsService;
        }

        public void Initialize()
        {
            _endOfGameManager.OnVictory += OnVictory;
            _endOfGameManager.OnGameOver += OnGameOver;
            _resultPopup.OnRestartClicked += OnRestartClicked;
        }

        public void Dispose()
        {
            _endOfGameManager.OnVictory -= OnVictory;
            _endOfGameManager.OnGameOver -= OnGameOver;
            _resultPopup.OnRestartClicked -= OnRestartClicked;
        }

        private void OnVictory() =>
            DetermineResult(true);

        private void OnGameOver() =>
            DetermineResult(false);

        private void DetermineResult(bool value)
        {
            _resultPopup.Show();
            _resultPopup.ChangeResult(value);
            _resultPopup.ChangeNumberPoints(_pointsService.Points.ToString());
        }

        private void OnRestartClicked() =>
            SceneManager.LoadScene(0);
    }
}