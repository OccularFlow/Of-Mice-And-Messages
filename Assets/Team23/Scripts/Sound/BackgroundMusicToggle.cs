using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicToggle : PauseMenuButton
{
	[SerializeField] private Sprite ONSprite;
	[SerializeField] private Sprite OFFSprite;
	private BackgroundMusic bgmusic;
	bool musicOn;

	protected void Start()
	{
		bgmusic = FindObjectOfType<BackgroundMusic>();
		musicOn = (PlayerPrefs.GetInt("BackgroundMusic") == 1) ? true : false;
		updateSprite();
	}

	public override void OnMouseDown()
	{
		if (musicOn == true)
		{
			bgmusic.music_off();
		}
		else
		{
			bgmusic.music_on();
		}
		musicOn = !musicOn;
		updateSprite();
	}

	public void musicChanged() {
		musicOn = true;
		updateSprite();
	}

	private void updateSprite()
	{
		spriteRenderer.sprite = musicOn ? ONSprite : OFFSprite;
	}
}
