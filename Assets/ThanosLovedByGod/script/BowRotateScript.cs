using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRotateScript : MonoBehaviour
{
	private Transform playerTransform;
	public Flip flip;
	
	private void Start()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Thanos").GetComponent<Transform>();
		
		if(flip == null)
			Debug.Log("Slothman Flip wurde nicht gesetzt. Bitte reintun (frag Andre)");
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		if(flip.FacingRight)
			transform.right = (playerTransform.position - transform.position);
		else
			transform.right = (playerTransform.position - transform.position) * -1;
	}
}
