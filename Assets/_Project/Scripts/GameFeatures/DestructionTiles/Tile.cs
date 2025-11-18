using System;
using _Project.Core.IndependentComponents;
using _Project.Core.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.DestructionTiles
{
    public abstract class Tile : MonoBehaviour, IDamage
    {
        [SerializeField] private float _healthValue = 10f;
        [SerializeField, Range(0f, 1f)] private float _timeDestroy = 0.1f;
        [SerializeField] private int _givesPoints;

        private PointsService _pointsService;
        private Health _health;
        private bool _isDead;

        public event Action OnTileDeath;

        [Inject]
        public void Construct(PointsService pointsService) =>
            _pointsService = pointsService;

        protected void Initialize()
        {
            _health = new Health(_healthValue);
            _health.OnDeath += OnDeath;
        }

        public void Damage(int damage) =>
            _health.TakeDamage(damage);

        private void OnDestroy() =>
            _health.OnDeath -= OnDeath;

        private async void OnDeath()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;
            await StartDeath();
        }

        private async UniTask StartDeath()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_timeDestroy),
                cancellationToken: this.GetCancellationTokenOnDestroy());

            _pointsService.AddPoint(_givesPoints);
            OnTileDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}