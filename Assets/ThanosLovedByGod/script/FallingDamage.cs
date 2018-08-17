using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDamage : MonoBehaviour {

    public DamageValue DV;


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8 || collision.collider.tag == "Stone")
        {
            DV.SetGrounded(true);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.collider.tag == "Stone")
        
        DV.SetGrounded(false);
        
    }
}
