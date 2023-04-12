using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class RotatePlayerSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly Transform _cameraObject;

        public RotatePlayerSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
            _cameraObject = Camera.main.transform;
        }

        public void Execute()
        {
            if (_gameContext.isLocalPlayer)
            {
                GameEntity localPlayer = _gameContext.localPlayerEntity;
                Vector2 axesValue = _inputContext.moveInput.value;

                Vector3 targetDirection = _cameraObject.forward * axesValue.y;
                targetDirection += _cameraObject.right * axesValue.x;
                targetDirection.Normalize();
                targetDirection.y = 0;

                if (targetDirection == Vector3.zero)
                {
                    targetDirection = localPlayer.gameView.transform.forward;
                }

                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Quaternion playerRotation = Quaternion.Slerp(localPlayer.gameView.transform.rotation, 
                    targetRotation, localPlayer.rotationSpeed.value * Time.fixedDeltaTime);

                localPlayer.gameView.transform.rotation = playerRotation;
            }
        }
    }
}
