using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPipeObs : IPipe
{
    protected override void Start() {
        base.Start();
        isFromDock = false;
    }

}
