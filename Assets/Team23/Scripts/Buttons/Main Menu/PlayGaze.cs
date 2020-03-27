using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayGaze : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        SceneManager.LoadScene("Level Grid", LoadSceneMode.Single);
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
