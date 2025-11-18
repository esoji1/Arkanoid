using System;

namespace _Project.Core.Services
{
    public class PointsService
    {
        private int _points;
        
        public int Points => _points;
        public event Action<int> OnAddPoints;
        
        public void AddPoint(int points)
        {
           
            
            _points += points;
            OnAddPoints?.Invoke(_points);
        }
        
        public void ChangePoints(int points)
        {
            if (points < 0)
            {
                return;
            }
            
            _points = points;
        }
    }
}