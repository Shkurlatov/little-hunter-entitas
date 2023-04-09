using Entitas;
using TMPro;

namespace LittleHunter.Launcher
{
    public class InitializePlayerNameSystem : IInitializeSystem
    {
        private readonly TMP_InputField _inputField;
        private readonly GameContext _gameContext;

        public InitializePlayerNameSystem(Contexts contexts, TMP_InputField inputField)
        {
            _inputField = inputField;
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            _inputField.onValueChanged.AddListener(OnViewUpdate);
        }

        private void OnViewUpdate(string newName)
        {
            _gameContext.ReplacePlayerName(newName);
        }
    }
}
