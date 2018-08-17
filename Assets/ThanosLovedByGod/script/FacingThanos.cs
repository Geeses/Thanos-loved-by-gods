using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingThanos : MonoBehaviour {

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Thanos").transform;
    }

    // Update is called once per frame
    void LateUpdate () {

        Vector2 direction = target.position - transform.position;  
        
        transform.up = direction;


	}
}
