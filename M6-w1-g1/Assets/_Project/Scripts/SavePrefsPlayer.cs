using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePrefsPlayer : MonoBehaviour
{
    [SerializeField] Slider volume;
    [SerializeField] Toggle VSync;
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
    }
    public float LoadVolume()
    {
        return PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void SetVSync()
    {
        if (VSync.isOn)
        {
            PlayerPrefs.SetInt("VSync",1);
        }
        else
        {
            PlayerPrefs.SetInt("VSync", 0);
        }
    }
    public void LoadVSync()
    {
        if (PlayerPrefs.GetInt("VSync") >= 1)
        {
            VSync.isOn = true;
        }
        else
        {
            VSync.isOn= false;
        }

    }
    private void OnEnable()
    {
        volume.value = LoadVolume();
        LoadVSync();
    }
}
