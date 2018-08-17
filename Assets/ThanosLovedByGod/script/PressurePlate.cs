using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> Interactables;
    private IntBehaviour behave;

    private SpriteRenderer actualSpriter;
    private Spriteholder s;
    private Player player;
    private bool used;
    public AudioClip pressureSound;

    private void Start()
    {
        player = ReInput.players.GetPlayer(0);
        actualSpriter = GetComponent<SpriteRenderer>();
        s = GetComponent<Spriteholder>();
        actualSpriter.sprite = s.onSprite;
        used = false;
    }

    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Thanos" || collision.tag == "Movables" ||collision.tag =="Gegner") && !used)
        {
            actualSpriter.sprite = s.offSprite;
            SoundManager.instance.PlaySingle(pressureSound);
            foreach (GameObject x in Interactables)
            {
                behave = x.GetComponent<IntBehaviour>();
                if (behave == null)
                {
                    behave = x.GetComponentInChildren<IntBehaviour>();
                }
                
                behave.enable = !behave.enable;

            }

            used = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Thanos" || collision.tag == "Movables" || collision.tag == "Gegner")
        {
            actualSpriter.sprite = s.onSprite;
            foreach (GameObject x in Interactables)
            {
                behave = x.GetComponent<IntBehaviour>();
                if (behave == null)
                {
                    behave = x.GetComponentInChildren<IntBehaviour>();
                }    
                behave.enable = !behave.enable;
                
            }

            used = false;
        }
    }
}




