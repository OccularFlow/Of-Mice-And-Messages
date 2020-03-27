﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGridFromPause : PauseMenuButton
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Grid", LoadSceneMode.Single);
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
