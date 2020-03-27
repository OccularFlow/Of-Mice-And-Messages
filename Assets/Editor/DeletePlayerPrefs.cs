using UnityEngine;
using UnityEditor;

public class DeletePlayerPrefs : EditorWindow
{
    [MenuItem("Window/Delete Player Pref")]
    static void deleteConsent(){
        // PlayerPrefs.DeleteKey("consent");
        PlayerPrefs.DeleteAll();
    }
}
