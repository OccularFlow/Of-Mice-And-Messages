using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : Button
{
    public override void OnMouseDown()
	{
        SceneManager.LoadScene("Level Grid");
    }

    public override float getGazeTime()
    {
        return GazeSettings.getExtendedDwellTime();
    }
}
