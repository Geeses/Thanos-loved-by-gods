using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManKI : MonoBehaviour {

    public float speed = 1.0f;
    public float attackTime = 3f;
    public float distance = 4;
    public float attackCD=5;

    private float buffer;
    private Transform player;
    private Camera triggercam;
    private Vector2 smoothVelocity = Vector2.zero;
    private Vector2 attackAim;
    private bool move=true;
    private bool attack=false;
    private bool dirRight;
    private Animator anim;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Thanos").transform;

        triggercam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        anim = GetComponentInChildren<Animator>();

        
    }



   void Update()
    {
        MoveState();
        AttackState();
    }







    private void MoveState()
    {
        
        Vector3 screenPoint = triggercam.WorldToViewportPoint(transform.position); // wenn gegner in die Kamera läuft
        bool onScreen = screenPoint.z >= 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // bool der guckt wo der Gegner ist im Vergleich zur Kamera
        if (onScreen == true)
        {

            if (move)
            {
                       
                Vector2 target = new Vector2(transform.position.x, player.transform.position.y + 10);
                transform.position = Vector2.SmoothDamp(transform.position, target, ref smoothVelocity, attackTime, 1000, Time.deltaTime);// Gegner bewegt sich auf Spieler zu
                if (dirRight)
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                else
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);

                if (transform.position.x >= player.transform.position.x + distance)
                {
                    dirRight = false;

                }

                if (transform.position.x <= player.transform.position.x - distance)
                {
                    dirRight = true;

                }
                if (Time.time - buffer > attackCD)
                {
                    move = false;
                    attack = true;
                    anim.SetTrigger("IdleToAttack");
                    
                }
            }
            
        }
    }

    void AttackState()
    {
        attackAim = player.position;
        if(attack)transform.position = Vector2.SmoothDamp(transform.position, attackAim, ref smoothVelocity, attackTime, 1000, Time.deltaTime);// Gegner bewegt sich auf Spieler zu       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Thanos" || collision.tag == "Tilemap")
        {
            move = true;
            attack = false;
            anim.SetTrigger("AttackToIdle");
            buffer = Time.time;
        }
    }
    
}