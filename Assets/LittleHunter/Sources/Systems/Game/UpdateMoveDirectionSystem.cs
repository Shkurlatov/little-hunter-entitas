using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class UpdateMoveDirectionSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;
        private readonly Transform _cameraTransform;
        private readonly IGroup<GameEntity> _entities;

        public UpdateMoveDirectionSystem(Contexts contexts, Transform cameraTransform)
        {
            _inputContext = contexts.input;
            _cameraTransform = cameraTransform;
            _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveDirection));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.isLocalPlayer)
                {
                    Vector2 axesValue = _inputContext.moveInput.value;

                    Vector3 moveDirection = _cameraTransform.forward * axesValue.y;
                    moveDirection += _cameraTransform.right * axesValue.x;
                    moveDirection.Normalize();
                    moveDirection.y = 0;
                    moveDirection *= entity.movementSpeed.value;
                    entity.ReplaceMoveDirection(moveDirection);
                    entity.isMoving = moveDirection != Vector3.zero;
                }
            }
        }
    }
}
