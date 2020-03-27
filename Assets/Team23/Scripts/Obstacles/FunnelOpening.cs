using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelOpening : MonoBehaviour
{
    bool latchOpen = false;

    public void toggleLatch() {
        gameObject.SetActive(latchOpen);
        latchOpen = !latchOpen;
    }
}
