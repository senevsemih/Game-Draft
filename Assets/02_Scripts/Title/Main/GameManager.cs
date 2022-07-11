using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _02_Scripts.Title.Main
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private Config _Config;
        public Config Config => _Config;

        [ShowInInspector, ReadOnly] private int _currentSceneIndex = 1;
        
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindObjectOfType<GameManager>();

                if (_instance != null) return _instance;
                var obj = new GameObject();
                _instance = obj.AddComponent<GameManager>();

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            { 
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _currentSceneIndex = 1;
            
            if (SceneManager.GetActiveScene().buildIndex != 0) return;
            SceneManager.LoadScene(_currentSceneIndex, LoadSceneMode.Additive);
            _currentSceneIndex++;
        }

        [Button]
        private void LoadNextLevel()
        {
            var totalSceneCount = SceneManager.sceneCountInBuildSettings;
            if (_currentSceneIndex >= totalSceneCount) return;
            
            
            SceneManager.UnloadSceneAsync(_currentSceneIndex - 1);
            SceneManager.LoadScene(_currentSceneIndex, LoadSceneMode.Additive);
            _currentSceneIndex++;
        }
    }
}