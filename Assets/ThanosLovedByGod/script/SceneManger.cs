using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour {
  
  public Object sceneToSwitch;
  private ZeusController zc;

  private void Start()
  {
    zc = FindObjectOfType<ZeusController>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Thanos")

      zc.menu.progress += 1;
      SceneManager.LoadScene(sceneToSwitch.name); 
      
    }
}
