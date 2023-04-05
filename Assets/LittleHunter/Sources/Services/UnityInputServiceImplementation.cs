using UnityEngine;
using UnityEngine.InputSystem;

namespace LittleHunter
{
    public class UnityInputServiceImplementation : IInputService
    {
        private readonly UnityInput input;
        private Vector2 movement = Vector2.zero;
        private Vector2 look = Vector2.zero;

        public Vector2 GetMovement
        {
            get { return movement; }
        }


        public Vector2 GetLook
        {
            get { return look; }
        }

        public UnityInputServiceImplementation()
        {
            if (input == null)
            {
                input = new UnityInput();

                input.Player.Move.performed += Move;
                input.Player.Move.canceled += Move;

                input.Player.Look.performed += Look;
                input.Player.Look.canceled += Look;

                input.Player.Enable();
            }
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            movement = ctx.ReadValue<Vector2>();
        }

        private void Look(InputAction.CallbackContext ctx)
        {
            look = ctx.ReadValue<Vector2>();
        }

        public void Dispose()
        {
            if (input.Player.enabled)
            {
                input.Player.Disable();
            }
        }
    }
}
