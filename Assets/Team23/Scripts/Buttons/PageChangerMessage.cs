using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChangerMessage : Button
{
    [SerializeField] private Sprite nextPage;
    [SerializeField] private Sprite nextPageSelected;
    [SerializeField] private Sprite previousPage;
    [SerializeField] private Sprite previousPageSelected;
    [SerializeField] private MessageDisplayer messageDisplayer;
    private bool onFirstPage = true;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        onFirstPage = !onFirstPage;
        if (onFirstPage) {
            spriteRenderer.sprite = previousPageSelected;
            Invoke("flashes", 0.1f);
            messageDisplayer.previousPage();
        } else {
            spriteRenderer.sprite = nextPageSelected;
            Invoke("flashes", 0.1f);
            messageDisplayer.nextPage();
        }
    }

    void OnEnable() {
        spriteRenderer.sprite = nextPage;
        onFirstPage = true;
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
