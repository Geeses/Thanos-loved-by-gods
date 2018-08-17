using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_CS_CursorOver_NM_1 : MonoBehaviour {

    private bool entered;
    private Collider2D target;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        target = collision;
       
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
    }

    public bool GetEntered()
    {
        return entered;
    }

    public Collider2D GetTarget()
    {
        return target;
    }

}
