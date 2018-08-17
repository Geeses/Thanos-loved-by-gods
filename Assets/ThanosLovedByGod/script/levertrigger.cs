using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levertrigger : MonoBehaviour {
   public Lever testlever;

    private void OnTriggerStay2D(Collider2D collision)
    { //if (collision.tag == "RechtsBox")
        {
            testlever = collision.gameObject.GetComponent<Lever>();
            testlever.SetStage(2);
        }
    }
}
