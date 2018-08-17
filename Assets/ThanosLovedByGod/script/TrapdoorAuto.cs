using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorAuto : MonoBehaviour {
    private IntBehaviour auto;
    public int resetTime=2;
    public int triggerTime=2;

	// Use this for initialization
	void Start () {
        auto = gameObject.GetComponent<IntBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TrapDoor());       
    }
    

    IEnumerator TrapDoor()
        {
           
        yield return new WaitForSeconds(triggerTime);
        auto.enable = true;
        yield return new WaitForSeconds(resetTime);
        auto.enable = false;

             
           
        }
}
