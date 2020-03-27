using System;
using UnityEngine;
public class LevelButton : Button
{
    [SerializeField] private Sprite[] StarSprites1;
    [SerializeField] private Sprite[] StarSprites2;

    private readonly Color lockedLevelColor = Color.grey;
    private GazeableObject gazeableObject;
    [SerializeField] private int levelName;
    private bool completed = false;
    private int starsAchieved = 0;

    protected override void Awake() {
        base.Awake();
        gazeableObject = GetComponent<GazeableObject>();
    }
    void Start() {
        spriteRenderer.sprite = StarSprites1[0];
        if (!checkIfLevelIsAvailable()) {
            return;
        }
        starsAchieved = XMLHandler.GetStarsAcheived(levelName,false);       
        updateSprite();
    }

    void updateSprite() {
        if (levelName <= 15) {
            switch (starsAchieved)
            {
                case 0:
                    spriteRenderer.sprite = StarSprites1[0];
                    break;
                case 1:
                    spriteRenderer.sprite = StarSprites1[1];
                    break;
                case 2:
                    spriteRenderer.sprite = StarSprites1[2];
                    break;
                case 3:
                    spriteRenderer.sprite = StarSprites1[3];
                    break;
            }
        } else {
            switch (starsAchieved)
            {
                case 0:
                    spriteRenderer.sprite = StarSprites2[0];
                    break;
                case 1:
                    spriteRenderer.sprite = StarSprites2[1];
                    break;
                case 2:
                    spriteRenderer.sprite = StarSprites2[2];
                    break;
                case 3:
                    spriteRenderer.sprite = StarSprites2[3];
                    break;
            }
        }
    }

    bool checkIfLevelIsAvailable() {
        if (XMLHandler.findHighestLevelReached(false) < levelName) {
            if (levelName > 15) {
                spriteRenderer.sprite = StarSprites2[0];
            } else {
                spriteRenderer.sprite = StarSprites1[0];
            }
            spriteRenderer.color = lockedLevelColor;
            gazeableObject.enabled = false;
            enabled = false;
            return false;
        }
        starsAchieved = XMLHandler.GetStarsAcheived(levelName,false);
        enabled = true;
        return true;
        
    }

    public override void OnMouseDown() {
        if (enabled) {
            soundManager.playSound("button");
            LevelLoader.loadLevel(levelName);
        }
    }


    void updateButton()
    {
        spriteRenderer.color = originalColor;
        enabled = true;
        gazeableObject.enabled = true;
        updateSprite();
    }
    public void nextPage() {
        levelName += 15;
        if (!checkIfLevelIsAvailable()) {
            return;
        }
        updateButton();
    }

    public void previousPage() {
        levelName -= 15;
        if (!checkIfLevelIsAvailable()) {
            return;
        }
        updateButton();
    }

}