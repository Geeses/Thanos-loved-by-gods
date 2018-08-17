using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CS_ThunderMovement_NM_1 : MonoBehaviour
{


    public float Velocity = 700f;           //Schussgeschwindigkeit
    private Rigidbody2D rb;                 //Referenz auf eigenes RB
    private Transform spawnPoint;           //Referenz auf den Emitter
    Vector2 moveDirection;

    void Start()
    {

        spawnPoint = GameObject.FindGameObjectWithTag("ThunderSpawn").transform;    //Hier bekommen wir den Transform des "Armes" von zeus.
        rb = GetComponent<Rigidbody2D>();

        moveDirection = spawnPoint.transform.up;                           //Die Richtung, in welches das Projektil fliegen soll, entspricht der Richtung des Armes
        rb.AddForce(moveDirection * Velocity);                                      //Richtung * Geschwindigkeit = Bewegung des Projektils
    }

    private void Update()
    {
        transform.up = rb.velocity;
    }

}