using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Photon.Pun;

namespace LittleHunter.Launcher
{
    public class ConnectionSystem : ReactiveSystem<NetworkEntity>, ICleanupSystem
    {
        private readonly NetworkContext _networkContext;
        private readonly GameContext _gameContext;
        private readonly SettingsContext _settingsContext;

        public ConnectionSystem(Contexts contexts) : base(contexts.network)
        {
            _networkContext = contexts.network;
            _gameContext = contexts.game;
            _settingsContext = contexts.settings;
        }

        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
        {
            return context.CreateCollector(NetworkMatcher.ShouldConnect);
        }

        protected override bool Filter(NetworkEntity entity)
        {
            return entity == _networkContext.shouldConnectEntity;
        }

        protected override void Execute(List<NetworkEntity> entities)
        {
            if (_gameContext.hasPlayerName)
            {
                if (PhotonNetwork.IsConnected)
                {
                    PhotonNetwork.JoinRandomRoom();
                }
                else
                {
                    PhotonNetwork.ConnectUsingSettings();
                }

                _networkContext.isPendingConnection = true;
            }
        }

        public void Cleanup()
        {
            _networkContext.isPendingConnection = false;
        }
    }
}
