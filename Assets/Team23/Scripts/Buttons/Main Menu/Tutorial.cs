using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : Button
{
    public override void OnMouseDown()
    {
        soundManager.playSound("button");
        LevelLoader.loadTutorial();

    }

    public override float getGazeTime() {
        return GazeSettings.getExtendedDwellTime();
    }
}
