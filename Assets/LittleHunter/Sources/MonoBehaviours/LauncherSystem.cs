using System;
using UnityEngine;
using UnityEngine.UI;
using Entitas;
using Photon.Pun;
using TMPro;

namespace LittleHunter.Launcher
{
    public sealed class LauncherSystem : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField _playerNameField;
        [SerializeField] private Button _startConnectButton;
        [SerializeField] private CanvasGroup _loadingScreen;

        public event Action OnPhotonConnectedToMaster;
        public event Action<object[]> OnPhotonRandomJoinFailed;
        public event Action OnPhotonJoinedRoom;

        private Systems _systems;
        private Systems _serverSystems;
        private Contexts _contexts;
        private bool _serverSystemInitialized = false;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

            _contexts = Contexts.sharedInstance;
            _systems = new Feature("Launcher Systems");
            _serverSystems = new Feature("Server Systems");

            _systems.Add(new InitializePlayerNameSystem(_contexts, _playerNameField));
            _systems.Add(new InitializeStartButtonSystem(_contexts, _startConnectButton));
            _systems.Add(new ConnectionSystem(_contexts, this));
            _systems.Add(new ConnectionUISystem(_contexts, _loadingScreen));

            _serverSystems.Add(new LoadingLobbySystem(_contexts));
        }

        private void Start()
        {
            _systems.Initialize();
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (!_serverSystemInitialized)
                {
                    _serverSystemInitialized = true;
                    _serverSystems.Initialize();
                }

                _serverSystems.Execute();
                _serverSystems.Cleanup();
            }

            _systems.Execute();
            _systems.Cleanup();
        }

        #region MonoBehaviourPunCallbacks Callbacks

        public override void OnConnectedToMaster()
        {
            OnPhotonConnectedToMaster?.Invoke();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            var codeAndMsg = new object[] { returnCode, message };

            OnPhotonRandomJoinFailed?.Invoke(codeAndMsg);
        }

        public override void OnJoinedRoom()
        {
            OnPhotonJoinedRoom?.Invoke();
        }

        #endregion
    }
}
