using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float timer;
    public void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        timer = Time.time + PlayerPrefs.GetFloat("totalPlayTime",0);
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.RoundToInt(timer % 60).ToString("00");
        timerText.SetText(minutes + ":" + seconds);
    }

}
