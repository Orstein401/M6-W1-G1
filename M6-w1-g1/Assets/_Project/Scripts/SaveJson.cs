using System.Collections;
using System.Collections.Generic;
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
        PLayerData data = new PLayerData();
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
            PLayerData data = JsonUtility.FromJson<PLayerData>(json);
            transform.position = data.lastPosition;
            transform.rotation = data.lastRotation;
        }

    }
}
