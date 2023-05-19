using UnityEngine;
using Entitas;
using UnityEngine.InputSystem;

namespace LittleHunter
{
    public class CameraRotateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly SettingsContext _settingsContext;
        private readonly Transform _cameraTransform;
        private readonly Transform _cameraPivotTransform;

        private Transform _targetTransform;
        private float _cameraRotationAxis = default;

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
            _targetTransform = _gameContext.localPlayerEntity.gameView.transform;
            _gameContext.ReplaceCameraLookSpeed(_settingsContext.gameSettings.value.CameraConfig.CameraLookSpeed);
        }

        public void Execute()
        {
            if (_gameContext.isLocalPlayer)
            {
                Vector2 axesValues = _inputContext.lookInput.value;

                if (axesValues.x != 0)
                {
                    if (IsKeyboardOrMouse())
                    {
                        _cameraRotationAxis += axesValues.x * _gameContext.cameraLookSpeed.value * Time.deltaTime;
                    }
                    else
                    {
                        _cameraRotationAxis += axesValues.x * _gameContext.cameraLookSpeed.value;
                    }

                    _cameraTransform.eulerAngles = new Vector3(
                        _targetTransform.eulerAngles.x,
                        _cameraRotationAxis,
                        _targetTransform.eulerAngles.z);
                }
            }
        }

        private bool IsKeyboardOrMouse()
        {
            return Keyboard.current.anyKey.isPressed
                || Mouse.current.leftButton.isPressed
                || Mouse.current.rightButton.isPressed
                || Mouse.current.middleButton.isPressed
                || Mouse.current.delta.ReadValue() != default;
        }
    }
}
