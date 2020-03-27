using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : PauseMenuButton
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

    public override float getGazeTime() {
        return GazeSettings.getExtendedDwellTime();
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
