using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;
    GameManager gameManager;

    protected override void Awake(){
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void OnMouseDown() {
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        gameManager.pause();
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
