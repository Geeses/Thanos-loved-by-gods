using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneLoad : MonoBehaviour
{

	public bool triggerLoad;

	[SerializeField]
	private int scene;

	private AsyncOperation async;

	private void Start()
	{
		async = SceneManager.LoadSceneAsync(scene);
		async.allowSceneActivation = false;
	}

	private void Update()
	{
		if (triggerLoad && async.isDone) {
			

		}
	}

	public void nowLoad()
	{
		async.allowSceneActivation = true;
		SceneManager.LoadScene(scene);
	}
}
