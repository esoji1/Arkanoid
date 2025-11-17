using _Project.GameFeatures.Input;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.PlatformManagement
{
    public class Movement : ITickable, IInitializable
    {
        private readonly InputController _inputController;
        private readonly Transform _platformTransform;

        private UnityEngine.Camera _mainCamera;
        private float _platformY;

        public Movement(InputController inputController, Transform platformTransform)
        {
            _inputController = inputController;
            _platformTransform = platformTransform;
        }

        public void Initialize()
        {
            _mainCamera = UnityEngine.Camera.main;
            _platformY = _platformTransform.position.y;
        }

        public void Tick() =>
            Move();

        private void Move()
        {
            Vector2 input = _inputController.TappingScreen.ReadValue<Vector2>();
            
            if (input == Vector2.zero)
            {
                return;
            }
            
            float tappingScreenPositionWorldX = _mainCamera.ScreenToWorldPoint(new Vector3(input.x, 0f, 0f)).x;
            _platformTransform.position = new Vector3(tappingScreenPositionWorldX, _platformY, 0f);
        }
    }
}