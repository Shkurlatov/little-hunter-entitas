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
        private readonly LauncherSystem _callbackCaller;

        public ConnectionSystem(Contexts contexts, LauncherSystem callbackCaller) : base(contexts.network)
        {
            _networkContext = contexts.network;
            _gameContext = contexts.game;
            _settingsContext = contexts.settings;
            _callbackCaller = callbackCaller;

            _callbackCaller.OnPhotonConnectedToMaster += OnConnectedToMaster;
            _callbackCaller.OnPhotonRandomJoinFailed += OnPhotonRandomJoinFailed;
            _callbackCaller.OnPhotonJoinedRoom += OnJoinedRoom;
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

                PhotonNetwork.NickName = _gameContext.playerName.value;

                _networkContext.isPendingConnection = true;
            }
        }

        public void Cleanup()
        {
            _networkContext.isPendingConnection = false;
        }

        private void OnConnectedToMaster()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        private void OnPhotonRandomJoinFailed(object[] obj)
        {
            PhotonNetwork.CreateRoom("SandboxRoom", new Photon.Realtime.RoomOptions()
            {
                MaxPlayers = (byte)_settingsContext.gameSettings.value.NetworkConfig.MaxNumberOfPlayers
            }, null);
        }

        private void OnJoinedRoom()
        {
            Debug.Log("Room Joined: " + PhotonNetwork.CurrentRoom.Name);
            _networkContext.isPendingConnection = false;
            _networkContext.isConnectionSuccessful = true;
        }
    }
}
