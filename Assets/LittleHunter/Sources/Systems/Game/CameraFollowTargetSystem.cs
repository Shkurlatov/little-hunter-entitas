using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class CameraFollowTargetSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly SettingsContext _settingsContext;
        private readonly Transform _cameraTransform;

        private Transform _targetTransform;
        private Vector3 _cameraFollowVelocity = Vector3.zero;

        public CameraFollowTargetSystem(Contexts contexts, Transform cameraTransform)
        {
            _gameContext = contexts.game;
            _settingsContext = contexts.settings;
            _cameraTransform = cameraTransform;
        }

        public void Initialize()
        {
            _targetTransform = _gameContext.localPlayerEntity.gameView.transform;
            _gameContext.ReplaceCameraSmoothTime(_settingsContext.gameSettings.value.CameraConfig.CameraSmoothTime);
        }

        public void Execute()
        {
            if (_gameContext.isLocalPlayer)
            {
                Vector3 targetPosition = Vector3.SmoothDamp(_cameraTransform.position,
                    _targetTransform.position, ref _cameraFollowVelocity,
                    _gameContext.cameraSmoothTime.value);

                _cameraTransform.position = targetPosition;
            }
        }
    }
}
