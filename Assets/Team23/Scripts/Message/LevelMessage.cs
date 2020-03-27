using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class LevelMessage : MonoBehaviour
{
    [SerializeField] MessagePageChanger messagePageChanger;
    private List<string> messages;
    public TextMeshProUGUI message;
    void Awake()
    {
        messages = XMLHandler.GetMessages();
    }

    void Start() {
        message.SetText(messages[0]);
        if (messages[1] == "None") {
            messagePageChanger.gameObject.SetActive(false);
        }
    }

    public void nextPage() {
        message.SetText(messages[1]);
    }

    public void previousPage() {
        message.SetText(messages[0]);
    }
    
}
