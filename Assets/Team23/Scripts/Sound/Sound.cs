using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    private static Sound instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance != this)
		{
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        float timer = Time.time + PlayerPrefs.GetFloat("totalPlayTime",0);
        PlayerPrefs.SetFloat("totalPlayTime",timer);
    }


}
