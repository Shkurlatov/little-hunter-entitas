using UnityEngine;
using UnityEngine.InputSystem;

namespace LittleHunter
{
    public class UnityInputServiceImplementation : IInputService
    {
        private readonly UnityInput _input;
        private Vector2 _movement = Vector2.zero;
        private Vector2 _look = Vector2.zero;

        public Vector2 GetMovement
        {
            get { return _movement; }
        }


        public Vector2 GetLook
        {
            get { return _look; }
        }

        public UnityInputServiceImplementation()
        {
            if (_input == null)
            {
                _input = new UnityInput();

                _input.Player.Move.performed += Move;
                _input.Player.Move.canceled += Move;

                _input.Player.Look.performed += Look;
                _input.Player.Look.canceled += Look;

                _input.Player.Enable();
            }
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            _movement = ctx.ReadValue<Vector2>();
        }

        private void Look(InputAction.CallbackContext ctx)
        {
            _look = ctx.ReadValue<Vector2>();
        }

        public void Dispose()
        {
            if (_input.Player.enabled)
            {
                _input.Player.Disable();
            }
        }
    }
}
