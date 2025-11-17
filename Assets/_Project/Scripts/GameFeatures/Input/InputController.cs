using UnityEngine.InputSystem;

namespace _Project.GameFeatures.Input
{
    public class InputController
    {
        private readonly PlayerInput _playerInput;
        
        public InputAction TappingScreen { get; private set; }

        public InputController(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            TappingScreen = _playerInput.actions["TappingScreen"];
        }
    }
}