using UnityEngine;

public class ButtonManager : MonoBehaviour {
    private DeactivatableButton[] deactivatableButtons;
    void Awake() {
        deactivatableButtons = FindObjectsOfType<DeactivatableButton>();
    }

    public void deactivateButtons() {
        foreach (DeactivatableButton button in deactivatableButtons) {
            button.deactivate();
        }
    }

    public void activateButtons() {
        foreach (DeactivatableButton button in deactivatableButtons) {
            button.activate();
        }
    }
}
