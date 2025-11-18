using System;
using _Project.Core.Services;
using Zenject;

namespace _Project.GameFeatures.UI.PointsView
{
    public class PointsPresenter : IInitializable, IDisposable
    {
        private readonly PointsService _pointsService;
        private readonly PointsView _pointsView;

        public PointsPresenter(PointsService pointsService, PointsView pointsView)
        {
            _pointsService = pointsService;
            _pointsView = pointsView;
        }

        public void Initialize()
        {
            _pointsService.ChangePoints(0);
            OnAddPoints(_pointsService.Points);
            _pointsService.OnAddPoints += OnAddPoints;
        }

        public void Dispose() => 
            _pointsService.OnAddPoints -= OnAddPoints;

        private void OnAddPoints(int points) =>
            _pointsView.AddPoints(points.ToString());
    }
}