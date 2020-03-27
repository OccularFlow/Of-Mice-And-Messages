using UnityEngine;

public class DwellPauseButton : PauseMenuButton, IDwellButton
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite selectedSprite;
    [SerializeField] DwellSpeeds dwellSpeed;
    private float dwellTime;
    private DwellController dwellController;
    
    override protected void Awake() {
        base.Awake();
        dwellController = GetComponentInParent<DwellController>();
        switch (dwellSpeed) {
            case DwellSpeeds.slow:
                dwellTime = GazeSettings.slowDwellTime;
                break;
            case DwellSpeeds.medium:
                dwellTime = GazeSettings.mediumDwellTime;
                break;
            case DwellSpeeds.fast:
                dwellTime = GazeSettings.fastDwellTime;
                break;
        }
    }
    public override void OnMouseDown() {
        dwellController.updateGazeTime(dwellTime);
        spriteRenderer.sprite = selectedSprite;
        soundManager.playSound("button");
    }

    public float getDwellTime() {
        return dwellTime;
    }

    public void unselected() {
        spriteRenderer.sprite = normalSprite;
    }

    public void selected() {
        spriteRenderer.sprite = selectedSprite;
    }
}

