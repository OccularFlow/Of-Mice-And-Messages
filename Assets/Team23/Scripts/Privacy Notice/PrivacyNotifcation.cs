using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyNotifcation : MonoBehaviour
{
    public GameObject Yes;
    public GameObject No;

    public GameObject playButton;
    public GameObject exitButton;
    public GameObject settingButton;
    public GameObject messagesButton;

    void Start() {
        if (!PlayerPrefs.HasKey("consent")) {
            PlayerPrefs.SetInt("consent", 0);
        }
        if (PlayerPrefs.GetInt("consent") == 1) {
            destroyChildObjects();
            Destroy(gameObject);
            return;
        }
        toggleButtons(false);
    }
    public void consented() {
        toggleButtons(true);
        destroyChildObjects();
        Destroy(gameObject);
        // PlayerPrefs.SetInt("Consent",1);
    }

    void toggleButtons(bool value) {
        messagesButton.SetActive(value);
        playButton.SetActive(value);
        exitButton.SetActive(value);
        settingButton.SetActive(value);
    }

    void destroyChildObjects() {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}
