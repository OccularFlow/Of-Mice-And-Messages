using UnityEngine;

public abstract class DeactivatableButton : Button {
    private BoxCollider2D objectCollider;
    private GazeableObject gazeableObject;

    protected override void Awake() {
        base.Awake();
        gazeableObject = GetComponent<GazeableObject>();
        objectCollider = GetComponent<BoxCollider2D>();
    }
    public void deactivate() {
        gazeableObject.enabled = false;
        objectCollider.enabled = false;
        spriteRenderer.color = Color.gray;
    }

    public void activate() {
        gazeableObject.enabled = true;
        objectCollider.enabled = true;
        spriteRenderer.color = originalColor;
    }
}
