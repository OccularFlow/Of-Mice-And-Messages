using TMPro;
using UnityEngine;

public class ExitMessage : Button
{
    [SerializeField] private GameObject messageDisplayer;

    [SerializeField] private GameObject pageChanger;

    public override void OnMouseDown()
    {
        soundManager.playSound("button");
        messageDisplayer.SetActive(true);
        pageChanger.SetActive(false);
    }
    public override float getGazeTime()
    {
        return GazeSettings.getExtendedDwellTime();
    }
}
