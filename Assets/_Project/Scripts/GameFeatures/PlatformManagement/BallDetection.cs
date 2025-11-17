using _Project.GameFeatures.BallManagement;
using UnityEngine;
using _Project.ScriptableObjects;
using Zenject;

namespace _Project.GameFeatures.PlatformManagement
{
    public class BallDetection : MonoBehaviour
    {
        private PlatformConfig _platformConfig;

        [Inject]
        public void Construct(PlatformConfig platformConfig) =>
            _platformConfig = platformConfig;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball _))
            {
                GiveStrengthCertainDirection(other);
            }
        }

        private void GiveStrengthCertainDirection(Collision other)
        {
            Rigidbody ballRigidbody = other.collider.GetComponent<Rigidbody>();
            Vector3 hitPoint = other.contacts[0].point;
            Vector3 platformCenter = new Vector3(transform.position.x, transform.position.y);

            ballRigidbody.linearVelocity = Vector3.zero;
            float difference = hitPoint.x - platformCenter.x;

            if (hitPoint.x < platformCenter.x)
            {
                ballRigidbody.AddForce(new Vector2(-Mathf.Abs(
                    difference * _platformConfig.ImpactForceX), _platformConfig.ImpactForceY));
            }
            else
            {
                ballRigidbody.AddForce(new Vector2(Mathf.Abs(
                    difference * _platformConfig.ImpactForceX), _platformConfig.ImpactForceY));
            }
        }
    }
}