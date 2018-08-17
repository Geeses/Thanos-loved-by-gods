using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class GroßerButton : MonoBehaviour
{
    public List<GameObject> Interactables;
    public float timer;
    
    private IntBehaviour behave;
    private bool used = false;
    private Player player;
    private Spriteholder s;
    private SpriteRenderer actualSpriter;
    public AudioClip großerButtornSound;
   
    // Use this for initialization
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
        actualSpriter = GetComponent<SpriteRenderer>();
        s = GetComponent<Spriteholder>();
        actualSpriter.sprite = s.onSprite;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Movables"||collision.tag =="Thanos" )
        {
            if (!used)
            {
                SoundManager.instance.PlaySingle(großerButtornSound);
                used = true;
                actualSpriter.sprite = s.offSprite;


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

                if (timer > 0)
                {
                    StartCoroutine("disableAfterTime");
                }
                
            }
        }
    }
    
    private IEnumerator disableAfterTime()
    {
        yield return new WaitForSeconds(timer);

        foreach (GameObject x in Interactables)
        {
            behave = x.GetComponent<IntBehaviour>();
            if(behave == null)
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
        used = true;

        actualSpriter.sprite = s.onSprite;
    }

}

