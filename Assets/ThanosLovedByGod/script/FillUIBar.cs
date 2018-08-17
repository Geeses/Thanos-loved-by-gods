using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillUIBar : MonoBehaviour
{

	public Image UIBar;
	public Attack_ScriptableObject grab;
	
	private Collect col;

	private void Start()
	{
		col = GetComponent<Collect>();
	}

	// Update is called once per frame
	void Update ()
	{
		UIBar.fillAmount = col.GetActualScore() / grab.AchievementLevel;	
		
		Debug.Log(grab.AchievementLevel);
		Debug.Log(col.GetActualScore());

	}
}
