using UnityEngine;
using Entitas;

namespace LittleHunter
{
    public class MovePlayerSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        public MovePlayerSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            if (_gameContext.isLocalPlayer) 
            {
                GameEntity localPlayer = _gameContext.localPlayerEntity;
                localPlayer.physicsView.value.velocity = localPlayer.moveDirection.value;
            }
        }
    }
}
