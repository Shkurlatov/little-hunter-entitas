using UnityEngine;
using UnityEngine.SceneManagement;

namespace LittleHunter
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private string _firstSceneName;
        public GameSettingsData GameSettings;

        private Contexts _contexts;
        private SettingsContext _settingsContext;
        private GameSystems _gameSystems;

        public static bool IsQuitting { get; private set; }

        private void Awake()
        {
            Application.quitting += delegate { IsQuitting = true; };
            DoAwake();
        }

        private void DoAwake()
        {
            DontDestroyOnLoad(this);
            _contexts = Contexts.sharedInstance;
            _settingsContext = _contexts.settings;

            UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

            LoadSettings();

            _gameSystems = new GameSystems(_contexts);
        }

        private void Start()
        {
            _gameSystems.Initialize();
            SceneManager.LoadSceneAsync(_firstSceneName, LoadSceneMode.Additive);
        }

        private void Update()
        {
            _gameSystems.Execute();
        }

        private void LoadSettings()
        {
            _settingsContext.SetGameSettings(GameSettings);
        }

        private void OnApplicationQuit()
        {
            _gameSystems.TearDown();
        }
    }
}
