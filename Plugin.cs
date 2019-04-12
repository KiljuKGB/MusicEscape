using System.Linq;
using IllusionPlugin;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MusicEscape
{
    public class Plugin : IPlugin
    {
        public string Name => "Music Escape";
        public string Version => "1.0";

        private bool _init = false;

        static Plugin instance;

        public void OnApplicationStart()
        {
            if (_init) return;
            _init = true;
            instance = this;

            PauseManager.OnLoad();
        }

        public static string PluginName
        {
            get
            {
                return instance.Name;
            }
        }


        public void OnApplicationQuit()
        {
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance = null;
        static PauseMenuManager pauseMenuManager;
        static StandardLevelGameplayManager gameplayManager;

        public static void OnLoad()
        {
            if (Instance != null) return;
            new GameObject("Mediocre Loader Manager").AddComponent<PauseManager>();

        }

        public static bool isGameScene(Scene scene)
        {

            return (scene.name == "GameCore");
        }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape) && isGameScene(SceneManager.GetActiveScene()))
            {
                pauseMenuManager = Resources.FindObjectsOfTypeAll<PauseMenuManager>().First();
                gameplayManager = Resources.FindObjectsOfTypeAll<StandardLevelGameplayManager>().First();
                gameplayManager.HandlePauseTriggered();
                pauseMenuManager.MenuButtonPressed();

            }
        }

    }
}
