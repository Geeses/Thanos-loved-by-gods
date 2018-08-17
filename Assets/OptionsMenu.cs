using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour {
    public AudioMixer mixer;
    public GameObject Pausenmenü;
    public GameObject Cursor;
    public MainMenuScritable menu;
    public Text volume;
    public Text cursorspeed;

    private void Update()
    {
        float mixvol;

        if (mixer.GetFloat("volume", out mixvol))
        mixvol = mixvol + 80f;
        volume.text = mixvol.ToString();
        cursorspeed.text = menu.cursorspeed.ToString();

    }


    public void setVolume(float i)
    {
        mixer.SetFloat("volume", i);
    }
    public void increaseVolume()
    {
        float i = 0;
        if(mixer.GetFloat("volume", out i))   
        mixer.SetFloat("volume",i+5 );
    }
    public void decreaseVolume()
    {
        float i = 0;
        if (mixer.GetFloat("volume", out i))
            mixer.SetFloat("volume", i-5);

    }
    public void closeMenu()
    {
        Cursor.transform.position = new Vector3(35.95f, 37.35f, -1.73f);
        Pausenmenü.SetActive(false);

    }
    public void increaseCursorSpeed()
    {
        menu.cursorspeed = menu.cursorspeed + 5;

    }
    public void decreaseCursorSpeed()
    {
        menu.cursorspeed = menu.cursorspeed - 5;
    }
}
