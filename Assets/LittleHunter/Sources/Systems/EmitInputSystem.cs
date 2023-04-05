using Entitas;
using UnityEngine;

namespace LittleHunter
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
    {
        private InputContext inputContext;
        private IInputService inputService;

        public EmitInputSystem(Contexts contexts, IInputService inputService)
        {
            inputContext = contexts.input;
            this.inputService = inputService;
        }

        public void Initialize()
        {
            inputContext.SetMoveInput(Vector2.zero);
            inputContext.SetLookInput(Vector2.zero);
        }

        public void Execute()
        {
            inputContext.ReplaceMoveInput(inputService.GetMovement);
            inputContext.ReplaceLookInput(inputService.GetLook);
        }

        public void TearDown()
        {
            inputService.Dispose();
        }
    }
}
