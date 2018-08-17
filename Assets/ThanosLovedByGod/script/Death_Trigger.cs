using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Trigger : MonoBehaviour {
	
	/*
	 * Scene wird neugestartet wenn der Collider von etwas mit dem Tag "Thanos" geentered wird
	 */

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Thanos")
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
