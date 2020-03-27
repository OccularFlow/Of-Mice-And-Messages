using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsToggle : PauseMenuButton
{
    [SerializeField] private Sprite ONSprite;
    [SerializeField] private Sprite OFFSprite;
    private bool soundOn;

    protected void Start()
    {
        soundOn = (PlayerPrefs.GetInt("Sound") == 1) ? true : false;
        updateSprite();
    }

    public override void OnMouseDown()
	{
        soundOn = !soundOn;
        soundManager.toggleSounds(soundOn);
        soundManager.playSound("button");
        updateSprite();
	}

    private void updateSprite()
    {
        spriteRenderer.sprite = soundOn ? ONSprite : OFFSprite;
    }

}
