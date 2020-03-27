using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour
{
    LevelButton[] levelButtons;

    void Awake() {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }

    public void nextPage() {
        foreach (LevelButton levelButton in levelButtons) {
            levelButton.nextPage();
        }
    }

    public void previousPage() {
        foreach (LevelButton levelButton in levelButtons) {
            levelButton.previousPage();
        }
    }
}
