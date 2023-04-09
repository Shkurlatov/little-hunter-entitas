using Entitas;
using UnityEngine.UI;

namespace LittleHunter.Launcher
{
    public class InitializeStartButtonSystem : IInitializeSystem, ICleanupSystem
    {
        private readonly Button _button;
        private readonly NetworkContext _networkContext;

        public InitializeStartButtonSystem(Contexts contexts, Button button)
        {
            _button = button;
            _networkContext = contexts.network;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnPressed);
        }

        private void OnPressed()
        {
            _networkContext.isShouldConnect = true;
        }

        public void Cleanup()
        {
            _networkContext.isShouldConnect = false;
        }
    }
}
