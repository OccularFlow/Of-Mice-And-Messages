using UnityEngine;

public class FinishPipe : MonoBehaviour
{
    private GameManager gameManager;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.gameObject.SetActive(false);
        if (collision.tag == "message bottle") {
            DropletPool.instance.bottleLost();
            gameManager.levelCompleted();
        }
    }
}
