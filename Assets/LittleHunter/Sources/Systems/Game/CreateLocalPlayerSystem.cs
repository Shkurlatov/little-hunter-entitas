using Entitas;
using UnityEngine;

namespace LittleHunter
{
    public class CreateLocalPlayerSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly SettingsContext _settingsContext;

        public CreateLocalPlayerSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _settingsContext = contexts.settings;
        }

        public void Initialize()
        {
            _gameContext.isLocalPlayer = true;

            GameObject playerView = Photon.Pun.PhotonNetwork.Instantiate(
                _settingsContext.gameSettings.value.PlayerConfig.PlayerPrefab.name,
                _gameContext.spawnPoint.position,
                _gameContext.spawnPoint.rotation,
                0
                );

            GameEntity localPlayer = _gameContext.localPlayerEntity;
            localPlayer.AddGameView(playerView, playerView.transform);
            localPlayer.AddPhysicsView(playerView.GetComponent<Rigidbody>());
            localPlayer.AddPhotonView(playerView.GetComponent<Photon.Pun.PhotonView>());
        }
    }
}
