using UnityEngine;
    public enum DwellSpeeds
    {
        slow,
        medium,
        fast
    }
public class DwellController : MonoBehaviour
{
    IDwellButton[] dwellTimeButtons;

    void Awake() {
        dwellTimeButtons = GetComponentsInChildren<IDwellButton>();
    }

    void Start() {
        foreach (IDwellButton button in dwellTimeButtons) {
            if (button.getDwellTime() == GazeSettings.getDwellTime()) {
                button.selected();
                return;
            }
        }
    }

    public void updateGazeTime(float newGazeTime) {
        GazeSettings.setDwellTime(newGazeTime);
        foreach (IDwellButton button in dwellTimeButtons) {
            if (button.getDwellTime() != GazeSettings.getDwellTime()) {
                button.unselected();
            }
        }
    }



}
