
using UnityEngine;
using System.IO;
public class SaveJson : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Application.persistentDataPath + "/DataPlayer.json";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Load();
        }

    }
    public void Save()
    {
        PlayerData data = new PlayerData();
        data.lastPosition = transform.position;
        data.lastRotation = transform.rotation;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
    public void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            transform.position = data.lastPosition;
            transform.rotation = data.lastRotation;
        }

    }
}
