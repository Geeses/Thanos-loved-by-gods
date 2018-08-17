using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

    
    public bool AimPlayer=false;

    private Vector2 FlipPos;
    private bool flipped_right = false;
    private bool flipped_left = true;
    private Transform ObjectToAimAt;
    private PlayerController PlayerControllerSkript;
    private Transform Root;
    public bool FacingRight;
    public bool FacingLeft;

    private void Awake()
    {
        Root = this.gameObject.transform;

        if (AimPlayer)
        {
            ObjectToAimAt = GameObject.FindGameObjectWithTag("Thanos").transform;
            
        }
         
        else
        {
            PlayerControllerSkript = GetComponent<PlayerController>();
        }
    }

    private void Update()
    {
        FlipGameObject();
        
    }

    public void FlipGameObject()
    {
       
        if (ObjectToAimAt)
        {
            FacingRight = (ObjectToAimAt.position.x > Root.position.x);
            FacingLeft = !FacingRight;
        }
        else
        {
            FacingRight = PlayerControllerSkript.FacingRight();
            FacingLeft = PlayerControllerSkript.FacingLeft();
        }

        if (FacingRight)
        {
            if (!flipped_right)
            {
                Root.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
               
                flipped_right = true;
                flipped_left = false;
            }

        }
        else
        {
            if (!flipped_left && FacingLeft)
            { 

                Root.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
               
                flipped_left = true;
                flipped_right = false;
            }
        }
    }
}
