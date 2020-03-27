using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    protected override void Awake() {
        base.Awake();
        if (PlayerPrefs.GetInt("currentLevel") == 30) {
            gameObject.SetActive(false);
        }
    }
    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        LevelLoader.nextLevel();
    }


    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
