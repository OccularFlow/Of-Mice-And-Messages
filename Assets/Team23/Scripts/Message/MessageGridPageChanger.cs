using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageGridPageChanger : Button
{
    [SerializeField] private Sprite nextPage;
    [SerializeField] private Sprite nextPageSelected;
    [SerializeField] private Sprite previousPage;
    [SerializeField] private Sprite previousPageSelected;
    private MessageSelector[] messageSelectors;
    private bool onFirstPage = true;

    protected override void Awake() {
        base.Awake();
        messageSelectors = FindObjectsOfType<MessageSelector>();
    }
    public override void OnMouseDown() {
        soundManager.playSound("button");
        onFirstPage = !onFirstPage;
        if (onFirstPage) {
            spriteRenderer.sprite = previousPageSelected;
            Invoke("flashes", 0.1f);
            foreach (MessageSelector messageSelector in messageSelectors) {
                messageSelector.previousPage();
            }
        } else {
            spriteRenderer.sprite = nextPageSelected;
            Invoke("flashes", 0.1f);
            foreach (MessageSelector messageSelector in messageSelectors) {
                messageSelector.nextPage();
            }
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
