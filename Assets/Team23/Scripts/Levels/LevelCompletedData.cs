using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class LevelCompletedData : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] starSprites;
    private int stars;
    private string timeTaken;
    public TextMeshProUGUI displayTime;
    public void Start()
    {
        // int currentLevel = PlayerPrefs.GetInt("currentLevel");
        // level = XMLHandler.getLevelInfo(currentLevel,false);
        // stars = level.Stars;
        // timeTaken = level.TimeTaken;
        stars = Int32.Parse(PlayerPrefs.GetString("stars"));
        float time = PlayerPrefs.GetFloat("time");
        string minutes = Math.Floor(time / 60).ToString("00");
        string seconds = Math.Round(time % 60).ToString("00");
        timeTaken = (minutes + ":" + seconds);
        displayTime.SetText(timeTaken);
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (stars)
        {
            case 0:
                break;
            case 1:
                spriteRenderer.sprite = starSprites[0];
                break;
            case 2:
                spriteRenderer.sprite = starSprites[1];
                break;
            case 3:
                spriteRenderer.sprite = starSprites[2];
                break;
        }

    }
}

