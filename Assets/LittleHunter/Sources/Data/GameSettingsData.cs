using System;
using UnityEngine;

namespace LittleHunter
{
    [CreateAssetMenu(fileName = "Assets/LittleHunter/Data/Settings/NewGameSettings", menuName = "LittleHunter/Data/Settings/Game", order = 0)]
    public class GameSettingsData : ScriptableObject
    {
        [Header("GameSettings")]
        public string GameVersion;
        public int BuildNumber;

        [Header("MultiplayerSettings"), Space(2f)]
        public NetworkPreset NetworkConfig;

        [Serializable]
        public class NetworkPreset
        {
            public int MaxNumberOfPlayers;
            public string RoomSceneName;
        }
    }
}
