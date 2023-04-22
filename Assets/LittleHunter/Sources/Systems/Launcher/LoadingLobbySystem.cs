using System.Collections.Generic;
using Entitas;
using Photon.Pun;

namespace LittleHunter.Launcher
{
    public class LoadingLobbySystem : ReactiveSystem<NetworkEntity>
    {
        private readonly NetworkContext _networkContext;
        private readonly SettingsContext _settingsContext;

        public LoadingLobbySystem(Contexts contexts) : base(contexts.network)
        {
            _networkContext = contexts.network;
            _settingsContext = contexts.settings;
        }

        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
        {
            return context.CreateCollector(NetworkMatcher.ConnectionSuccessful.Added());
        }

        protected override bool Filter(NetworkEntity entity)
        {
            return entity == _networkContext.connectionSuccessfulEntity;
        }

        protected override void Execute(List<NetworkEntity> entities)
        {
            PhotonNetwork.LoadLevel(_settingsContext.gameSettings.value.NetworkConfig.RoomSceneName);
        }
    }
}
