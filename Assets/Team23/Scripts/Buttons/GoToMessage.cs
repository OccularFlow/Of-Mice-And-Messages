using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMessage : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        SceneManager.LoadScene("Message", LoadSceneMode.Single);
    }

    public override float getGazeTime() {
        return GazeSettings.getDwellTime();
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}