using UnityEngine;

public class RotateAntiClock : DeactivatableButton
{
    GameManager gameManager;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    protected override void Awake() {
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
    }
    public override void OnMouseDown() {
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        gameManager.rotateAntiClockwise();
    }

    private void flashes() {
        spriteRenderer.sprite = normalSprite;
    }
}
