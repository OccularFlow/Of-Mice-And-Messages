using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioClip gameMenu, moutain, puzzleGame;
    private AudioClip[] list_music = new AudioClip[3];
    private int current_music = 0;
    private AudioSource audio;

    private void Awake()
    {
        gameMenu = Resources.Load<AudioClip>("Sounds/Game-Menu_Looping");
        moutain = Resources.Load<AudioClip>("Sounds/Our-Mountain_v003_Looping");
        puzzleGame = Resources.Load<AudioClip>("Sounds/Puzzle-Game_Looping");
        list_music[0] = gameMenu;
        list_music[1] = moutain;
        list_music[2] = puzzleGame;
        audio = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("BackgroundMusic")) {
            PlayerPrefs.SetInt("BackgroundMusic",1);
        }
        if (!PlayerPrefs.HasKey("MusicChoice")) {
            PlayerPrefs.SetInt("MusicChoice",0);
        }
    }

    void Start()
    {
        
        current_music = PlayerPrefs.GetInt("MusicChoice");
        if (PlayerPrefs.GetInt("BackgroundMusic") == 1){
            music_on();
        }
    }

    public void music_off()
	{
        enabled = false;
        audio.Stop();
        PlayerPrefs.SetInt("BackgroundMusic", 0);
	}

    public void music_on()
	{
        enabled = true;
        audio.clip = list_music[current_music];
        audio.loop = true;
        audio.Play();
        PlayerPrefs.SetInt("BackgroundMusic", 1);
    }

    public void change_music()
    {
        current_music = (current_music + 1) % list_music.Length;
        PlayerPrefs.SetInt("MusicChoice", current_music);
        music_on();
    }
}
