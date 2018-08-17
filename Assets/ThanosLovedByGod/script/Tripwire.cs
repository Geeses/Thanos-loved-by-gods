using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Tripwire : MonoBehaviour
{
    public List<GameObject> Interactables;
    private IntBehaviour behave;
    private bool trigger = true;

    private SpriteRenderer actualSpriter;
    private Spriteholder s;
    private Player player;
    public AudioClip tripsound;

    private void Start()
    {
        player = ReInput.players.GetPlayer(0);
        actualSpriter = GetComponent<SpriteRenderer>();
        s = GetComponent<Spriteholder>();
        actualSpriter.sprite = s.onSprite;
    }
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Thanos" || collision.tag == "Thunder" || collision.tag == "Movables" || collision.tag == "Enemy")
        {
            actualSpriter.sprite = s.offSprite;
            if (trigger == true)
                SoundManager.instance.PlaySingle(tripsound);
            {
                trigger = false;

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
            }
        }
    }
}
