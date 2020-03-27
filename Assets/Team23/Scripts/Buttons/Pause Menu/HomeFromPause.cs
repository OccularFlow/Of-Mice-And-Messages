using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeFromPause : PauseMenuButton
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
