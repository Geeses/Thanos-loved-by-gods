using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CS_FacingTowardsCursor_NM_1 : MonoBehaviour {

    public Transform target;

	
	// Update is called once per frame
	void Update () {

        Vector2 direction = target.position - transform.position;  
        
        transform.up = direction;


	}
}
