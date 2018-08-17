using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public int progress = 0;
    public GameObject Wald;
    public GameObject Tempel;
    public GameObject Schnee;
    public MainMenuScritable menu;
    


    private void Update()
    {
        progress = menu.progress;
        if(progress > 0) Wald.SetActive(true);
        if(progress > 1) Tempel.SetActive(true);
        if(progress > 2) Schnee.SetActive(true);
    }



    public void setProgress(int i)
    {
        progress = i;
    }

   
}
