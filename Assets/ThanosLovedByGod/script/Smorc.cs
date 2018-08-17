using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Smorc : MonoBehaviour
{
    public Character character;
    public Transform groundTrigger; //transform des Groundtriggers
    public Transform walltriggerr;  //transform des Triggers für die rechte seite
    public Transform walltriggerl;  //transform des Triggers für die linke seite
    private Camera triggercam;       // kamera die die Bewegung auslöst
    private Rigidbody2D enemyrb;     // rb des Gegners
    private GameObject player;       // der Spieler der das Ziel ist
    public LayerMask groundLayer;   //layer für Boden
    public DamageValue DV;
    bool smorcing = false;
    bool isGrounded = false;        // bool zum gucken ob Gegner den Boden berührt
    bool jump = false;              // bool um die Fähigkeit zum Springen zu deaktivieren
    bool hitWallLeft = false;       // bool um zu gucken ob gegner links eine wand berührt
    bool hitWallRight = false;      // bool um die Fähigkeit zum Springen zu deaktivieren

    public float speed = 4.0F;      // Geschwindigkeit des Gegners 
    public float jumppower = 50f;   // Sprungstärke des Gegners
    public float TriggerRadius = 0.1f; // Radius für TriggerKollisionene
    public float jumpcd = 2.0f; // JumpCooldown
    public float jumpbuffer; // buffer als Speicher für Sprungabfragen
    public Ogre_Atack ogre;
    private Animator anim;
    public AudioClip OgreWalk;
    private bool inAir;
    private animationsoundevents events;

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetFloat("velocity", enemyrb.velocity.y);
        anim.SetBool("attacking", ogre.attacking);
        anim.SetBool("attackCooldown", ogre.attackingCooldown);
        
        jumppower = character.jumpPower;

        if (isGrounded && hitWallLeft || hitWallRight) // wenn der Gegner niedriger auf y achse ist als der spieler UND auf dem Boden ist                                                                                                           // UND entweder links ODER rechts eine Wand Berührt
        {
            jump = true;
           /* if ((Time.time - jumpbuffer) > jumpcd) // wenn Zeit seit letztem Sprung den Jumpcd nicht unterschreitet
            {
                jump = true; // jump ermöglichen
                jumpbuffer = Time.time;// zeit anpassen
            } */
        }
        
        anim.SetBool("inAir", !isGrounded);

    }
    void Start()
    {
        
        enemyrb = GetComponent<Rigidbody2D>(); // Anwendung auf rb des Gegners
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Thanos");
        triggercam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        events = GetComponent<animationsoundevents>();
    }

    private void Update()
    {
        
        isGrounded   = Physics2D.OverlapCircle(groundTrigger.position, TriggerRadius, groundLayer);// gucken ob der groundtrigger sich mit dem Groundlayer überlappt
        hitWallRight = Physics2D.OverlapCircle(walltriggerr.position, TriggerRadius, groundLayer); // gucken ob der walltrigger rechts sich mit dem Groundlayer überlappt
        hitWallLeft  = Physics2D.OverlapCircle(walltriggerl.position, TriggerRadius, groundLayer); // gucken ob der wallTrigger sich mit dem Groundlayer überlappt
        Triggermove();
        Jump();
        
    }


    void Triggermove()
    {
        Vector3 screenPoint = triggercam.WorldToViewportPoint(enemyrb.position); // wenn gegner in die Kamera läuft

        bool onScreen = screenPoint.z >= 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // bool der guckt wo der Gegner ist im Vergleich zur Kamera

        if (onScreen == true && !ogre.attacking && !anim.GetBool("dead") && !ogre.attackingCooldown)
        {
            //Debug.Log("sollte animieren");
            events.canStep = true;
            anim.SetTrigger("ToWalk");
            anim.SetBool("isIdle", false);
            
            Vector2 ptf = new Vector2(player.transform.position.x, enemyrb.position.y);
            transform.position = Vector2.MoveTowards(enemyrb.position, ptf, speed); // Gegner bewegt sich auf Spieler zu
            SoundManager.instance.PlaySingle(OgreWalk);
        }
        else
        {
            events.canStep = false;
        }
    }



    void Jump()
    {
        if (jump) // wenn jump true ist
        {
            jump = false; // jump auf flalse setzten
            enemyrb.AddForce(Vector2.up * jumppower * enemyrb.mass); // Kraft nach oben auf Gegner wirken
        }
    }
    void OnDrawGizmosSelected() // Zeichenen der Trigger
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(groundTrigger.position,TriggerRadius);
        Gizmos.DrawSphere(walltriggerl.position, TriggerRadius);
        Gizmos.DrawSphere(walltriggerr.position, TriggerRadius);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Thanos" && !ogre.hot)
        {

            IsSmorcing(false);
            anim.SetTrigger("ToAttack");
            

        }
    }*/

    public void onFinishedAttack()
    {
        ogre.attacking = false;
        ogre.DamageCollider.enabled = false;
        
        anim.SetBool("isIdle", true);
    }
}
