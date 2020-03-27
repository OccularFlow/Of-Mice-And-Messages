using TMPro;
using UnityEngine;

public class MessageSelector : Button
{
    [SerializeField] private int levelName;
    private readonly Color uncompletedColor = Color.grey;
    [SerializeField] Sprite[] levelSprites;
    private MessageDisplayer messageDisplayer;
    private GazeableObject gazeableObject;
    public void Start() {
        messageDisplayer = GetComponentInParent<MessageDisplayer>();
        gazeableObject = GetComponent<GazeableObject>();
        spriteRenderer.sprite = levelSprites[0];

        checkIfLevelUnlocked();
    }
    
    public override void OnMouseDown() {
        if (!enabled) {
            return;
        }
        soundManager.playSound("button");
        messageDisplayer.setMessage(levelName);
    }

    void updateButton() {
        if (levelName <= 15) {
            spriteRenderer.sprite = levelSprites[0];
        } else {
            spriteRenderer.sprite = levelSprites[1];
        }
        checkIfLevelUnlocked();
    }

    void checkIfLevelUnlocked() {
        if (levelName < XMLHandler.findHighestLevelReached(false)) {
            enabled = true;
            gazeableObject.enabled = true;
            spriteRenderer.color = originalColor;
        } else {
            enabled = false;
            gazeableObject.enabled = false;
            spriteRenderer.color = uncompletedColor;
        }
    }
    
    public void nextPage() {
        levelName += 15;
        updateButton();
    }

    public void previousPage() {
        levelName -= 15;
        updateButton();
    }
}
