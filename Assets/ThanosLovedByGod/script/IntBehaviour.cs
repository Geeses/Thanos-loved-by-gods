using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntBehaviour : MonoBehaviour
{
    [Header("Gate")]
    private Vector2 Gate;
    public float speed;
    public bool enable = false;
    private float step;
    private float doorstep = 5f;
    public bool invert;

    [Header("Door")]
    public Sprite closesprite;
    public Sprite opensprite;
    

    [Header("Spiketrap")]
    private DamageValue damage;
    public Sprite spikeon;
    public Sprite spikeoff;

    void Start()
    {
        Gate = new Vector2(transform.position.x, transform.position.y);
        step = speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        GateBehavior();
        DoorBehavior();
        SpikeBehavior();
        
    }


    private void GateBehavior()
    {
        if (gameObject.GetComponentInChildren<Transform>().tag == "Gate")
        {
            if (invert)
            {
                doorstep = -5f;
            }

            if (enable == true)
            {

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Gate.x, Gate.y + doorstep), step);
                gameObject.GetComponentInParent<Collider2D>().enabled = false;
            }
            else
            {
                {
                    gameObject.GetComponentInParent<Collider2D>().enabled = true;
                    transform.position = Vector2.MoveTowards(transform.position, Gate, step);
                }
            }
        }
    }
    private void DoorBehavior()
    {
        if (gameObject.tag == "Door")
        {

            if (enable == false)
            {

                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = closesprite;


            }

            else

            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = opensprite;


            }
        }
    }
    private void SpikeBehavior()
    {
        if(gameObject.tag == "SpikeTrap")
        {
           
            if (enable == true)
            {

                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = spikeon;

            }

            else

            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = spikeoff;
            }




        }




    }
}







   


