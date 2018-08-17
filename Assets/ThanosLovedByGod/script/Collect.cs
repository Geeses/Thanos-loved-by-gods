using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour {
    float score = 0;
    public float IncreaseAmount = 10;
    //public Text scoretext;
    public AudioClip burp;
    

    public float GetActualScore()
    {
        return score;
    }
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D other) // Collision
    {
        if (other.gameObject.tag=="Collectable") // Wenn anderes Object mit "Coin" getagt ist

        {
                
                Destroy(other.gameObject); // zerstören des Objektes
                score += IncreaseAmount; // erhöhen des Scores um 100
                                         //scoretext.text = score.ToString(); // anpassen des UI Textes
            SoundManager.instance.PlaySingle(burp);  
        }
     }
}
  




    
