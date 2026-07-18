using System.IO;
using UnityEngine;

namespace GmtkJam2026
{
    public sealed class SaveUtil : MonoBehaviour
    {
        public const string RootFolderName = "GmtkJam2026";
        public const string SaveFileName = "Savefile.json";

        public void Save<T>(string fileName, T data)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            string folder = $"idbfs/{RootFolderName}";
            if (!System.IO.Directory.Exists(folder)) System.IO.Directory.CreateDirectory(folder);
            string path = $"{folder}/{fileName}";
#else
            string path = $"{Application.persistentDataPath}/{fileName}";
#endif
            var dataString = JsonUtility.ToJson(data);
            File.WriteAllText(path, dataString);
            Debug.Log("Data saved");
        }

        public T Load<T>(string fileName)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            string path = $"idbfs/{RootFolderName}/{fileName}";
#else
            string path = $"{Application.persistentDataPath}/{fileName}";
#endif
            if (!File.Exists(path))
            {
                Debug.LogWarning($"Save file not found at {path}");
                return default;
            }

            var dataString = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(dataString);
            Debug.Log("Data loaded");
            return data;
        }
    }
}
