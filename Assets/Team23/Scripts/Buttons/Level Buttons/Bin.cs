using UnityEngine;

public class Bin : DeactivatableButton
{
    DockLevelGameManager gameManager;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    protected override void Awake() {
        base.Awake();
        gameManager = FindObjectOfType<DockLevelGameManager>();
    }

    public override void OnMouseDown() {
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        gameManager.binPipe();
    }
    private void flashes() {
        spriteRenderer.sprite = normalSprite;
    }
}
