using UnityEngine;

namespace GmtkJam2026
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private string _startScene;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            var prefab = Resources.Load<GameObject>("Managers");
            if (prefab == null)
            {
                Debug.LogError("Managers prefab not found in Resources folder.");
                return;
            }

            var managers = GameObject.Instantiate(prefab);
            GameObject.DontDestroyOnLoad(managers);
        }

        private async void Start()
        {
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_startScene);
        }
    }
}
