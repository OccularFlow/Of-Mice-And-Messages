using UnityEngine;

public static class GazeSettings
{
    private static float dwellTime;
    public static readonly float slowDwellTime = 2f;
    public static readonly float mediumDwellTime = 1f;
    public static readonly float fastDwellTime = 0.5f;


    public static float getDwellTime() {
        if (dwellTime > 0) {
            return dwellTime;
        }
        if (PlayerPrefs.HasKey("DwellTime"))
        {
            GazeSettings.setDwellTime(PlayerPrefs.GetFloat("DwellTime"));
        }
        else
        {
            GazeSettings.setDwellTime(mediumDwellTime);
        }
        return dwellTime;
    }

    public static float getExtendedDwellTime() {
        return GazeSettings.getDwellTime() * 1.25f;
    }

    public static void setDwellTime(float dwellTime) {
        GazeSettings.dwellTime = dwellTime;
        PlayerPrefs.SetFloat("DwellTime", dwellTime);
    }
}
