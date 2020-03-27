using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;
    private BackgroundMusic bgMusic;

    public override void OnMouseDown()
    {
        bgMusic = FindObjectOfType<BackgroundMusic>();
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        bgMusic.change_music();
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
