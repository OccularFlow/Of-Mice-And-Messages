using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePageChanger : Button
{
    [SerializeField] private Sprite nextPage;
    [SerializeField] private Sprite nextPageSelected;
    [SerializeField] private Sprite previousPage;
    [SerializeField] private Sprite previousPageSelected;
    [SerializeField] private LevelMessage levelMessage;
    private bool onFirstPage = true;

    public override void OnMouseDown() {
        onFirstPage = !onFirstPage;
        if (onFirstPage) {
            spriteRenderer.sprite = previousPageSelected;
            Invoke("flashes", 0.1f);
            levelMessage.previousPage();
        } else {
            spriteRenderer.sprite = nextPageSelected;
            Invoke("flashes", 0.1f);
            levelMessage.nextPage();
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
