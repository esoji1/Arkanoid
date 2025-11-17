using System;
using UnityEngine;

namespace _Project.Core.IndependentComponents
{
    public class Health
    {
        private float _current;
        
        public Health(float current) =>
            _current = current;
        
        public event Action OnDeath;
        
        public void TakeDamage(float damage)
        {
            _current = Mathf.Max(_current - damage, 0f);

            if (Mathf.Approximately(_current, 0f))
                OnDeath?.Invoke();
        }
    }
}