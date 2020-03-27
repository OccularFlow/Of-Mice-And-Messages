using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    readonly static List<int> easyLevels = new List<int> {3,9,21,22,23,24,25,26,27,28,29,30};
    readonly static List<int> hardLevels = new List<int> {1,2,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20};

    public static void loadLevel(int level) {
        PlayerPrefs.SetInt("currentLevel", level);
        if (easyLevels.Contains(level)) {
            SceneManager.LoadScene("eye 6", LoadSceneMode.Single);
        } else if (hardLevels.Contains(level)) {
            SceneManager.LoadScene("eye 5", LoadSceneMode.Single);
        }
    }

    public static void restartLevel() {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (currentLevel == 0) {
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        } else {
            loadLevel(PlayerPrefs.GetInt("currentLevel"));
        }
    }

    public static void loadTutorial() {
        PlayerPrefs.SetInt("currentLevel", 0);
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public static void nextLevel() {
        loadLevel(PlayerPrefs.GetInt("currentLevel") + 1);
    }

}
