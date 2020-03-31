using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown()
    {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        Time.timeScale = 1;
        LevelLoader.restartLevel();
    }
    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
