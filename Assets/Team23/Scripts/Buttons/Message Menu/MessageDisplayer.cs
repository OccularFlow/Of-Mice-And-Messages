using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private GameObject pageChangerButton;
    private string message;
    private string message2;

    public void setMessage(int levelName) {
        List<string> messages = XMLHandler.GetMessages(levelName);
        message = messages[0];
        message2 = messages[1];
        if (message2 == "None") {
            pageChangerButton.SetActive(false);
        } else {
            pageChangerButton.SetActive(true);
        }
        messageText.SetText(message);
        messagePanel.SetActive(true);
        gameObject.SetActive(false);
        messageText.enabled = true;
    }

    void OnEnable() {
        messagePanel.SetActive(false);
        messageText.enabled = false;
    }

    public void nextPage() {
        messageText.SetText(message2);
    }

    public void previousPage() {
        messageText.SetText(message);
    }

    
    
}
