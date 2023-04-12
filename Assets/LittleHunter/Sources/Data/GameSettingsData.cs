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

        [Header("Player Settings"), Space(2f)]
        public PlayerSettings PlayerConfig;

        [Serializable]
        public class NetworkPreset
        {
            public int MaxNumberOfPlayers;
            public string RoomSceneName;
        }

        [Serializable]
        public class PlayerSettings
        {
            public GameObject PlayerPrefab;
            public float MovementSpeed;
            public float RotationSpeed;
        }
    }
}
