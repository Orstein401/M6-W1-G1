
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveJson2 : MonoBehaviour
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
        DataPlayer data = new DataPlayer();
        data.lastPositionX = transform.position.x;
        data.lastPositionY = transform.position.y;
        data.lastPositionZ = transform.position.z;

        data.lastRotationX = transform.rotation.x;
        data.lastRotationY = transform.rotation.y;
        data.lastRotationZ = transform.rotation.z;
        data.lastRotationW = transform.rotation.w;



        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }
    public void Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataPlayer data = JsonConvert.DeserializeObject<DataPlayer>(json);
            Vector3 newPosition= new Vector3(data.lastPositionX,data.lastPositionY,data.lastPositionZ);
            Quaternion newRotation= new Quaternion(data.lastRotationX,data.lastRotationY,data.lastRotationZ,data.lastRotationW);   
            transform.position = newPosition;   
            transform.rotation = newRotation;
        }
        

    }
}
