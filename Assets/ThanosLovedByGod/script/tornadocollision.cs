using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadocollision : MonoBehaviour {
    public Lever test;
    

 


    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tornado")
        {
            test = GetComponentInParent<Lever>();
            if (this.tag == "Rechtsbox")
            {
                test.SetStage(2);
            }
            if (this.tag == "LinksBox")
            {
                test.SetStage(-2);
            }
           
            


        }
    }
}
