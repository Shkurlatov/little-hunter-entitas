using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Photon.Pun;

namespace LittleHunter
{
    public class CreateSpawnPointSystem : IInitializeSystem
    {
        private readonly List<Transform> _spawnPoints;
        private readonly GameContext _gameContext;

        public CreateSpawnPointSystem(Contexts contexts, List<Transform> spawnPoints)
        {
            _spawnPoints = spawnPoints;
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            Transform spawner = _spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1];
            _gameContext.ReplaceSpawnPoint(spawner.position, spawner.rotation);
        }
    }
}
