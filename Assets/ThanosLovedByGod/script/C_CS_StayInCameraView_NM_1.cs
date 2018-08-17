using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CS_StayInCameraView_NM_1 : MonoBehaviour {

    public float ymin = 0.1f;
    public float ymax = 0.9f;
    public float xmin = 0.1f;
    public float xmax = 0.9f;
    // Update is called once per frame
    void FixedUpdate () {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position); //Wo steht der Spieler im Bezug auf den sichtbaren Raum der Kamera
        //pos.x = Mathf.Clamp01(pos.x);
        pos.x = Mathf.Clamp(pos.x, xmin, xmax);// im Verhältnis zu einer Zahl zwischen 0 und 1
        //pos.y = Mathf.Clamp01(pos.y);
        pos.y = Mathf.Clamp(pos.y, ymin, ymax);
        transform.position = Camera.main.ViewportToWorldPoint(pos);         //Setze die Position an diese Stelle zwischen 0/0/0 und 1/1/1 (Grenze des sichtbaren Raumes)
    }
}
