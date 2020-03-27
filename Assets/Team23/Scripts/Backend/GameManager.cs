using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
This class is used to manage the game when a level is being played.
It is used to communicate between the various different game components.
When the water is running, the user cannot change anything in the scene.
**/
public class GameManager : MonoBehaviour
{
    private StartPipe startPipe;
    protected bool isWaterRunning = false;
    protected Pipe currentSelectedPipe;
    protected SelectionBox selectionBox;
    protected ButtonManager buttonManager;
    protected SoundManagerScript soundManager;
    private int currentLevelName;
    private LevelTimer levelTimer;
    
    protected virtual void Awake() {
        selectionBox = FindObjectOfType<SelectionBox>();
        buttonManager = GetComponent<ButtonManager>();
        levelTimer = GetComponentInChildren<LevelTimer>();
        startPipe = FindObjectOfType<StartPipe>();

        soundManager = FindObjectOfType<SoundManagerScript>();

        currentLevelName = PlayerPrefs.GetInt("currentLevel");
    }
    protected virtual void Start() {
        buttonManager.deactivateButtons();
    }
    public void toggleWater() {
        startPipe.toggleWater();
        isWaterRunning = !isWaterRunning;
        soundManager.waterRun(isWaterRunning);

        if (isWaterRunning) {
            buttonManager.deactivateButtons();
            selectionBox.move(new Vector2(200,200));
            currentSelectedPipe = null;
        }
    }

    public virtual void pipeSelected(Pipe pipe) {
        if (isWaterRunning) {
            return;
        }
        currentSelectedPipe = pipe;
        soundManager.playSound("select");
        selectionBox.move(pipe.transform.position);
        buttonManager.activateButtons();
    }

    public void rotateAntiClockwise() {
        currentSelectedPipe.rotateAntiClockwise();
        soundManager.playSound("rotate");
    }

    public void rotateClockwise() {
        currentSelectedPipe.rotateClockwise();
        soundManager.playSound("rotate");
    }

    public void levelCompleted() {
        Invoke ("finishLevel", 0.5f);
    }

    private void finishLevel() {
        soundManager.waterRun(false);
        String starsAchieved = levelTimer.numberOfStarsAcheived().ToString();
        float timeTaken = levelTimer.currentTimer();
        writeLevelCompletion(starsAchieved,timeTaken);
        PlayerPrefs.SetString("stars",starsAchieved);
        PlayerPrefs.SetFloat("time",timeTaken);
        SceneManager.LoadScene("Game Won");
    }

    public void writeLevelCompletion(string stars, float time)
    {
        string[] previousTime = XMLHandler.GetCurrentBestTimeTaken(false).Split(':');
        float currentBestTimeInSec = Int32.Parse(previousTime[0]) * 60 + Int32.Parse(previousTime[1]);
        if ((currentBestTimeInSec > 0f && time < currentBestTimeInSec) || currentBestTimeInSec <= 0f )
        {
            string minutes = Math.Floor(time / 60).ToString("00");
            string seconds = Math.Round(time % 60).ToString("00");
            string timeString = (minutes + ":" + seconds);
            XMLHandler.WriteGameCompletion(currentLevelName,stars,timeString,false);
        }
    }
    
}
