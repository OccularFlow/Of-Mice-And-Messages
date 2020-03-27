using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScript : Button
{
    public override void OnMouseDown() {
        
        SceneManager.LoadScene("eye 5");
    }
    
    public override float getGazeTime() {
        return GazeSettings.getDwellTime();
    }
}
