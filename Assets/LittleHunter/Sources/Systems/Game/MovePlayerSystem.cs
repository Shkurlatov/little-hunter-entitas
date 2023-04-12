using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class MovePlayerSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly Transform _cameraObject;

        public MovePlayerSystem(Contexts contexts)
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

                Vector3 moveDirection = _cameraObject.forward * axesValue.y;
                moveDirection += _cameraObject.right * axesValue.x;
                moveDirection.Normalize();
                moveDirection.y = 0;
                moveDirection *= localPlayer.movementSpeed.value;

                localPlayer.physicsView.value.velocity = moveDirection;
            }
        }
    }
}
