using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_CS_OnCollisionDestroy_NM_V2 : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.attachedRigidbody)&&(!collision.attachedRigidbody.IsSleeping()))
        {
            collision.attachedRigidbody.velocity = Vector3.zero;
        }

        Destroy(this.gameObject);
    }
    

}
