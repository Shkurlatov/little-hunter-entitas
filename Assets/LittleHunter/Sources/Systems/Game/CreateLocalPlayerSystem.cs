using UnityEngine;
using Entitas;
using Entitas.Unity;

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
                _gameContext.spawnPoint.position, _gameContext.spawnPoint.rotation, 0);

            GameEntity localPlayer = _gameContext.localPlayerEntity;
            localPlayer.AddGameView(playerView, playerView.transform);
            localPlayer.AddPhysicsView(playerView.GetComponent<Rigidbody>());
            localPlayer.AddMovementSpeed(_settingsContext.gameSettings.value.PlayerConfig.MovementSpeed);
            localPlayer.AddRotationSpeed(_settingsContext.gameSettings.value.PlayerConfig.RotationSpeed);
            localPlayer.AddPhotonView(playerView.GetComponent<Photon.Pun.PhotonView>());
            localPlayer.AddMoveDirection(Vector3.zero);
            localPlayer.AddAnimatorView(playerView.GetComponentInChildren<Animator>());
            localPlayer.isMoving = false;

            playerView.Link(localPlayer);
        }
    }
}
