using UnityEngine;
public abstract class Button : MonoBehaviour, IGazeableObject
{
    protected SpriteRenderer spriteRenderer;
    protected Color originalColor;
    protected SoundManagerScript soundManager;
    protected virtual void Awake() {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        soundManager = FindObjectOfType<SoundManagerScript>();
    }
    public void gazeAction() {
        OnMouseDown();
    }
    public abstract void OnMouseDown();
    public virtual void currentlyGazing() {
        float rateOfColorChange = 0.2f;
        spriteRenderer.color = new Color(spriteRenderer.color.r- (rateOfColorChange * Time.deltaTime), spriteRenderer.color.g - (rateOfColorChange * Time.deltaTime), spriteRenderer.color.b- (rateOfColorChange * Time.deltaTime), spriteRenderer.color.a);
    }
    public virtual void stoppedGazing() {
        spriteRenderer.color = originalColor;
    }
    public virtual float getGazeTime() {
        return GazeSettings.getDwellTime();
    }

    
}
