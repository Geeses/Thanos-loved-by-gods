using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPath : MonoBehaviour {

    public Character character;

    [HideInInspector]
    public float Velocity =20f;           //Schussgeschwindigkeit
                 //Referenz auf eigenes RB
    private Transform player;

    private Rigidbody2D rb;
    private Vector2 dir;


    void Start () {

        Velocity = character.movementSpeed;
        
         //Hier bekommen wir den Transform des "Armes" von zeus.
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;


        Vector2 aim = player.position - transform.position ;
        dir = aim.normalized * Velocity; //Die Richtung, in welches das Projektil fliegen soll, entspricht der Richtung des Armes
        rb.AddForce(dir);  //Richtung * Geschwindigkeit = Bewegung des Projektils
        

    }
    





}
