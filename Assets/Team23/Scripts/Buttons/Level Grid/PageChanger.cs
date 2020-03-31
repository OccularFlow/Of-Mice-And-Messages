using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : Button
{

    [SerializeField] private Sprite nextPage;
    [SerializeField] private Sprite nextPageSelected;
    [SerializeField] private Sprite previousPage;
    [SerializeField] private Sprite previousPageSelected;
    [SerializeField] private LevelButtonManager levelButtonManager;
    private bool onFirstPage = true;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        onFirstPage = !onFirstPage;
        if (onFirstPage) {
            spriteRenderer.sprite = previousPageSelected;
            Invoke("flashes", 0.1f);
            levelButtonManager.previousPage();
        } else {
            spriteRenderer.sprite = nextPageSelected;
            Invoke("flashes", 0.1f);
            levelButtonManager.nextPage();
        }
    }

    private void flashes()
    {
        if (onFirstPage)
        {
            spriteRenderer.sprite = nextPage;
        }
        else
        {
            spriteRenderer.sprite = previousPage;
        }
    }

}