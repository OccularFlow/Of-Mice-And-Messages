using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private AudioClip waterRunningSound, selectSound, binSound, rotationSound, placementSound, buttonSound;
    private AudioSource audioSrc;
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        waterRunningSound = Resources.Load<AudioClip>("Sounds/waterRunning");
        selectSound = Resources.Load<AudioClip>("Sounds/ding.wav");
        binSound = Resources.Load<AudioClip>("Sounds/bin");
        placementSound = Resources.Load<AudioClip>("Sounds/Beep");
        rotationSound = Resources.Load<AudioClip>("Sounds/rotate");
        buttonSound = Resources.Load<AudioClip>("Sounds/buttons");
        if (!PlayerPrefs.HasKey("Sound")){
            PlayerPrefs.SetInt("Sound",1);
        }
        enabled = (PlayerPrefs.GetInt("Sound") == 1) ? true : false;
    }

    public void toggleSounds(bool soundOn) {
        PlayerPrefs.SetInt("Sound", soundOn ? 1 : 0);
        enabled = soundOn;
    } 
    public void waterRun(bool running)
    {
        if (!enabled)
		{
            return;
		}
        audioSrc.clip = waterRunningSound;
        audioSrc.loop = true;
        if (running)
        {
            audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }
    }
    public void playSound(string sound)
    {
        if (!enabled)
        {
            return;
        }
        switch (sound)
        {
            case "bin":
                audioSrc.PlayOneShot(binSound);
                break;
            case "rotate":
                audioSrc.PlayOneShot(rotationSound);
                break;
            case "select":
                audioSrc.PlayOneShot(selectSound);
                break;
            case "move":
                audioSrc.PlayOneShot(placementSound);
                break;
            case "button":
                audioSrc.PlayOneShot(buttonSound);
                break;
        }
    }

    public AudioSource AudioSrc
    {
        get => audioSrc;
        set => audioSrc = value;
    }
}

