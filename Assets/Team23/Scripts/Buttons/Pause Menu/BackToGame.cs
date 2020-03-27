using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : PauseMenuButton
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        for (int i = 0; i < SceneManager.sceneCount; i++) {
            if (SceneManager.GetSceneAt(i).name != "Pause") {
                Scene currentScene = SceneManager.GetSceneAt(i);
                foreach (GameObject gameObject in currentScene.GetRootGameObjects()) {
                    if (gameObject.tag != "Water" && gameObject.tag != "message bottle") {
                        gameObject.SetActive(true);
                    }
                }
                break;
            }
        }
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Pause");
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
