using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour, IGazeableObject
{
    FunnelOpening funnelOpening;
    SpriteRenderer backgroundSprite;

    void Awake() {
        funnelOpening = GetComponentInChildren<FunnelOpening>();
        backgroundSprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void OnMouseDown() {
        funnelOpening.toggleLatch();
    }

    public void currentlyGazing() {
        backgroundSprite.color = new Color(backgroundSprite.color.r,backgroundSprite.color.g,backgroundSprite.color.b, backgroundSprite.color.a + (0.3f * Time.deltaTime));
    }

    public void stoppedGazing() {
        backgroundSprite.color = backgroundSprite.color - new Color(0,0,0,backgroundSprite.color.a);
    }

    public void gazeAction() {
        OnMouseDown();
    }

    public float getGazeTime() {
        return GazeSettings.getExtendedDwellTime();
    }


}
