using _Project.Core.IndependentComponents;
using UnityEngine;

namespace _Project.GameFeatures.BallManagement
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IDamage tile))
            {
                tile.Damage(_damage);
            }
        }
    }
}