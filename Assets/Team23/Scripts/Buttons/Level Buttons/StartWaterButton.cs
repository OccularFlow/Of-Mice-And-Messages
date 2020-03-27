using UnityEngine;

public class StartWaterButton : Button
{
    [SerializeField] private Sprite normalSprite;
    GameManager gameManager;
    [SerializeField] private Sprite selectedSprite;
    private bool isWaterRunning;

    protected override void Awake() {
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer.sprite = normalSprite;
        isWaterRunning = false;
    }

    public override void OnMouseDown() {
        isWaterRunning = !isWaterRunning;
        if (isWaterRunning) {
            spriteRenderer.sprite = selectedSprite;
        } else {
            spriteRenderer.sprite = normalSprite;
        }
        gameManager.toggleWater();
    }
}
