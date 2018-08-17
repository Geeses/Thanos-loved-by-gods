using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Switch : MonoBehaviour
{
    public List<GameObject> Interactables;
    private IntBehaviour behave;
    private bool inTrigger;
    private bool activate = false;
    private SpriteRenderer actualSpriter;
    private Spriteholder s;
    private Player player;
    public AudioClip SwitchSound;

    private void Start()
    {
        player = ReInput.players.GetPlayer(0);
        actualSpriter = GetComponent<SpriteRenderer>();
        s = GetComponent<Spriteholder>();
        actualSpriter.sprite = s.onSprite;
    }
    private void Update()
    {
        if (player.GetButtonDown("Activate"))
        {
            if (inTrigger)
            {
                if (actualSpriter.sprite.Equals(s.onSprite))
                {
                    actualSpriter.sprite = s.offSprite;
                }
                else
                {
                    actualSpriter.sprite = s.onSprite;
                }


                foreach (GameObject x in Interactables)

                {
                    behave = x.GetComponent<IntBehaviour>();
                    if (behave == null)
                    {
                        behave = x.GetComponentInChildren<IntBehaviour>();
                    }
                    if (behave.enable == true)
                    {
                        behave.enable = false;
                    }
                    else
                    {
                        behave.enable = true;
                    }

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }


}




    

