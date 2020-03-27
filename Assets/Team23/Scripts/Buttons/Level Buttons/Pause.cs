using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        // Setting timeScale to 0 freezes all mechanics in unity and Update methods in Monobehaviour scripts
        Time.timeScale = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        // deactivate all objects in the game other than water particles so that they retain their velocity
        foreach (GameObject gameObject in currentScene.GetRootGameObjects()) {
            if (gameObject.tag != "Water" && gameObject.tag != "message bottle") {
                gameObject.SetActive(false);
            }
        }
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
