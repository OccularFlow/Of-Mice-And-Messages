using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPipeObs : LPipe
{
    protected override void Start() {
        base.Start();
        isFromDock = false;
    }
}
