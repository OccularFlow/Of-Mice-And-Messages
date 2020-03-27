using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LevelTimer : MonoBehaviour
{
    private int currentStarSprite;
    [SerializeField] private Sprite[] starImages;
    [SerializeField] Image starImage;
    private List<float> starTimes;
    [SerializeField] private TextMeshProUGUI timerText;
    private float startTime;
    private float rateOfChangeForBar;
    
    public Slider timerLoadingBar;
    void Start() {
        startTime = Time.time;
        currentStarSprite = 0;
        starTimes = XMLHandler.GetStarTimers(false);
        if (starTimes == null) {
            return;
        }
        InvokeRepeating ("updateTimerBar", 1f, 1f);
        rateOfChangeForBar = 1/starTimes[currentStarSprite];
    }
    

    void updateTimerBar() {
        updateTimer();

        timerLoadingBar.value -= rateOfChangeForBar;
        if (timerLoadingBar.value <= 0) {
            currentStarSprite++;
            timerLoadingBar.value = 1f;
            starImage.sprite = starImages[currentStarSprite];
            if (currentStarSprite > 1) {
                CancelInvoke();
                InvokeRepeating("updateTimer", 1f, 1f);
                return;
            }
            rateOfChangeForBar = 1/starTimes[currentStarSprite];
        }
    }

    void updateTimer() {
        float currentLevelTime = Time.time - startTime;
        string minutes = Mathf.Floor(currentLevelTime / 60).ToString("00");
        string seconds = Mathf.RoundToInt(currentLevelTime % 60).ToString("00");
        timerText.SetText(minutes + ":" + seconds);
    }
    public int numberOfStarsAcheived() {
        return 3 - currentStarSprite;
    }

    public float currentTimer()
    {
        return Time.time - startTime;
    }
}
