using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsGaze : Button
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite selectedSprite;

    public override void OnMouseDown() {
        // use the resetPreferences to reset consent notice, total play time and sount/music toggles
        // resetPreferences();
        soundManager.playSound("button");
        spriteRenderer.sprite = selectedSprite;
        Invoke("flashes", 0.3f);
        SceneManager.LoadScene("Settings Menu", LoadSceneMode.Single);
    }

    void resetPreferences() {
        PlayerPrefs.DeleteKey("BackgroundMusic");
        PlayerPrefs.DeleteKey("Sound");
        PlayerPrefs.DeleteKey("consent");
        PlayerPrefs.SetFloat("totalPlayTime", 0f);
    }

    private void flashes()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
