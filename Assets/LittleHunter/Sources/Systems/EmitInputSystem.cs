using Entitas;
using UnityEngine;

namespace LittleHunter
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private readonly InputContext _inputContext;
        private readonly IInputService _inputService;

        public EmitInputSystem(Contexts contexts, IInputService inputService)
        {
            _inputContext = contexts.input;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _inputContext.SetMoveInput(Vector2.zero);
            _inputContext.SetLookInput(Vector2.zero);
        }

        public void Execute()
        {
            _inputContext.ReplaceMoveInput(_inputService.GetMovement);
            _inputContext.ReplaceLookInput(_inputService.GetLook);
        }

        public void TearDown()
        {
            _inputService.Dispose();
        }
    }
}
