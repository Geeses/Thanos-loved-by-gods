using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Anima2D;
using System;

public class Lever : MonoBehaviour
{  public int Stage;

    [Header("Stage-2-----------------")]
    public List<GameObject> Interactables1;
    [Header("Stage-1-----------------")]
    public List<GameObject> Interactables2;
    [Header("Stage1-----------------")]
    public List<GameObject> Interactables3;
    [Header("Stage2-----------------")]
    public List<GameObject> Interactables4;





    private IntBehaviour behave;
    //private bool buttonPressed;
    private int stage = 0;
    private float right;
    private float left;
    private bool stay;
    private float stagebuffer;
    private Player player;
    public Bone2D bone;
    public AudioClip stagesound;
    
  






    // Use this for initialization
    void Start()
    {

        //buttonPressed = true;
        Stage = 0;
        player = ReInput.players.GetPlayer(0);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        stay = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Stage)
        { 

            case -2:
                if (Interactables1 != null)
                {
                    HandleStageMinus2();
                    bone.transform.eulerAngles = new Vector3(0, 0, 120);
                }
                break;
            case -1:
                if (Interactables2 != null)
                {
                    HandleStageMinus1();
                    bone.transform.eulerAngles = new Vector3(0, 0, 105);
                }
                break;
            case 0:

                HandleStage0();
                bone.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case 1:
                if (Interactables3 != null)
                {
                    HandleStagePlus1();
                    bone.transform.eulerAngles = new Vector3(0, 0, 75);
                }
                break;
            case 2:
                if (Interactables4 != null)
                {
                    HandleStagePlus2();
                    bone.transform.eulerAngles = new Vector3(0, 0, 60);
                }
                break;

        }
        if (player.GetButton("Activate") && player.GetButtonDown("LeverLinks") && stay)
        {
            SoundManager.instance.PlaySingle(stagesound);
           SwitchStatusLever("down");        
        }
        if (player.GetButton("Activate") && player.GetButtonDown("LeverRechts") && stay)
        {
            SoundManager.instance.PlaySingle(stagesound);
            SwitchStatusLever("up");
        }
    }

    private void SwitchStatusLever(string x)
    {
        if (x == "up")
        {
            if (Stage < 2)
                Stage++;
        }
        if (x == "down")
        {
            if (Stage > -2)
                Stage--;
        }



      
    }
    private void HandleStage0()
    {


        foreach (GameObject x in Interactables2)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
        foreach (GameObject x in Interactables3)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }

    }
    private void HandleStageMinus1()
    {
        foreach (GameObject x in Interactables1)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }

        foreach (GameObject x in Interactables2)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = true;
        }

    }
    private void HandleStageMinus2()
    {
        foreach (GameObject x in Interactables2)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }

        foreach (GameObject x in Interactables1)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = true;
        }


        foreach (GameObject x in Interactables3)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
        foreach (GameObject x in Interactables4)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
    }
  
    private void HandleStagePlus1()
    {
      
        foreach (GameObject x in Interactables4)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
        foreach (GameObject x in Interactables3)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = true;
        }

    }
    private void HandleStagePlus2()
    {
        foreach (GameObject x in Interactables3)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
        foreach (GameObject x in Interactables4)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = true;
        }
        foreach (GameObject x in Interactables1)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }
        foreach (GameObject x in Interactables2)
        {
            behave = x.GetComponent<IntBehaviour>();
            if (behave == null)
            {
                behave = x.GetComponentInChildren<IntBehaviour>();
            }
            behave.enable = false;
        }

    }
    public void SetStage(int i)
    {
        Stage = i;
    }
}
        
    
    

    

