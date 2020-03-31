using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : Button
{
    protected TutorialManager tutorialManager;
    public Sprite[] spriteList;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;


    protected override void Awake()
    {
        base.Awake();
        tutorialManager = FindObjectOfType<TutorialManager>();
        spriteRenderer.sprite = normalSprite;
    }
    public override void OnMouseDown()
    {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.1f);
    }

    public void flashes()
    {
        spriteRenderer.sprite = normalSprite;
        tutorialManager.nextPopUp();
    }
}
