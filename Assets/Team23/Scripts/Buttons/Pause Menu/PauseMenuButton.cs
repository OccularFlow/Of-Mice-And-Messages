using UnityEngine;
public abstract class PauseMenuButton : Button
{
    private float startTime = 0f;
    public override void currentlyGazing() {
        if (startTime == 0f) {
            startTime = Time.unscaledTime;
        }
        float rateOfColorChange = 0.2f;
        float currentGazeTime = Time.unscaledTime - startTime;
        spriteRenderer.color = new Color(originalColor.r - (rateOfColorChange * currentGazeTime), originalColor.g - (rateOfColorChange * currentGazeTime), originalColor.b - (rateOfColorChange * currentGazeTime), spriteRenderer.color.a);
    }

    public override void stoppedGazing() {
        spriteRenderer.color = originalColor;
        startTime = 0f;
    }
}
