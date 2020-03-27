using UnityEngine;

public class ExitGaze : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        Application.Quit();
    }

    public override float getGazeTime() {
        return GazeSettings.getExtendedDwellTime();
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
