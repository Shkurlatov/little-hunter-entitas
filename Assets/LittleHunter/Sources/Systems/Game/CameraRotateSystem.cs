using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class CameraRotateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly SettingsContext _settingsContext;
        private readonly Transform _cameraTransform;
        private readonly Transform _cameraPivotTransform;

        private float _lookAngle;
        private float _pivotAngle;
        private float _minimumPivotAngle;
        private float _maximumPivotAngle;

        public CameraRotateSystem(Contexts contexts, Transform cameraTransform, Transform cameraPivotTransform)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;
            _settingsContext = contexts.settings;
            _cameraTransform = cameraTransform;
            _cameraPivotTransform = cameraPivotTransform;
        }

        public void Initialize()
        {
            _minimumPivotAngle = _settingsContext.gameSettings.value.CameraConfig.MinimumPivotAngle;
            _maximumPivotAngle = _settingsContext.gameSettings.value.CameraConfig.MaximumPivotAngle;
            _gameContext.ReplaceCameraLookSpeed(_settingsContext.gameSettings.value.CameraConfig.CameraLookSpeed);
            _gameContext.ReplaceCameraPivotSpeed(_settingsContext.gameSettings.value.CameraConfig.CameraPivotSpeed);
        }

        public void Execute()
        {
            if (_gameContext.isLocalPlayer)
            {
                Vector2 axesValue = _inputContext.lookInput.value;

                _lookAngle += axesValue.x * _gameContext.cameraLookSpeed.value;
                _pivotAngle -= axesValue.y * _gameContext.cameraPivotSpeed.value;
                _pivotAngle = Mathf.Clamp(_pivotAngle, _minimumPivotAngle, _maximumPivotAngle);

                Vector3 rotation = Vector3.zero;
                rotation.y = _lookAngle;
                Quaternion targetRotation = Quaternion.Euler(rotation);
                _cameraTransform.rotation = targetRotation;

                rotation = Vector3.zero;
                rotation.x = _pivotAngle;

                targetRotation = Quaternion.Euler(rotation);
                _cameraPivotTransform.localRotation = targetRotation;
            }
        }
    }
}
