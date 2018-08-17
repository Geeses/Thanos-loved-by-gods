using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System;

public class PlayerController : MonoBehaviour {

    //Öffentliche Variablen
    
    private float speed = 10f;// speed Thanos
    private float jumppower = 50f;// Sprungstärke Thanos
    public Transform LeftFoot; //transform des Groundtriggers
    public Transform RightFoot;
    public LayerMask groundLayer;   //layer für Boden
    //public Renderer ShieldRenderer;
    public Collider2D ShieldCollider;
    public Renderer MeleeRenderer;
    public Collider2D MeleeCollider;
    public Character thanos;
    public float StaminaIncreaseAmountPerSecond;
    public float StaminaDecreaseAmountPerSecond;

    //Für Input
    private int playerID = 0;        //PlayerID für Rewired (0 = Thanos, 1= Zeus)
    private Player player;      //Player
   
        //Axis:
        private Vector2 moveVector;
        
        //Actions:
        private bool hit;
        private bool block;
        private bool jump;
        private bool activate;
        private bool pause;



    //Hilfsvariablen:
    private Rigidbody2D rb;
    private  GameObject Menu;
    private AttackController AC;

    private bool activated;
    private bool isGrounded = false; // bool umd zu gucken ob Thanos den boden berührt
    private bool facingLeft = false;// float zum zwischenspeichern der aktuellen geschwindigkeit
    private bool facingRight = false;
    private float groundTriggerRadius = 0.1f; //Triggerradius für den Groundtrigger
    private bool paused = false;
    private float delta;
    private float elsedelta;
    private ThanosStats ts;
    private Animator anim;
    private bool isJumping;
    

    void Awake()
    {
        AC = GetComponent<AttackController>();
        ts = GetComponent<ThanosStats>();
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerID);
        // Zugriff auf RB von Thanos
        rb = GetComponent<Rigidbody2D>(); 
  
    }


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        CheckForFlip(); 
        Blocking(false);
        Menu = GameObject.FindGameObjectWithTag("PauseMenu");
        delta           = Time.fixedTime;
        elsedelta       = Time.fixedTime;
    }

    
    void FixedUpdate()
    {
        anim.SetFloat("jumpVelocity", rb.velocity.y);
        
        CheckForStats();
        CheckForFlip();
        GetInput();
        ProcessInput();
        isGrounded = (Physics2D.OverlapCircle(LeftFoot.position, groundTriggerRadius, groundLayer)| Physics2D.OverlapCircle(RightFoot.position, groundTriggerRadius, groundLayer)); // gucken ob der groundtrigger sich mit dem Groundlayer überlappt
    }

    private void CheckForStats()
    {
        speed = thanos.movementSpeed;
        jumppower = thanos.jumpPower;
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.y = 0;
        
        anim.SetFloat("walking", moveVector.x);
        anim.SetFloat("walkingSpeed", moveVector.x);

        block = player.GetButton("Block");
        activate = player.GetButton("Activate");

        hit = player.GetButtonDown("Hit");
        jump = player.GetButtonDown("Jump");
        pause = player.GetButtonDown("Pause");

        
        
        if (rb.velocity.y > 1f || rb.velocity.y < -1f)
        {
            isJumping = true;
        } 
        else 
            isJumping = false;
        
        anim.SetBool("isJumping", isJumping);
    }

    private void ProcessInput()
    {
        Move();

        if (jump) Jump();

        if (hit) 
            AC.DoAttack("ThanosSword");
        else anim.SetBool("attack", false);

        Blocking(block);

        if (pause) Pause();

    }

    public void Pause()
    {
        //welt timer ausstellen

        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            Menu.SetActive(true);
           // Debug.Log("Paused");
        }
        else
        { 
            paused = false; 
            Time.timeScale = 1;
            Menu.SetActive(false);
          //  Debug.Log("UnPaused");
        }
        
        //pausenmenü öffnen


    }

    private void Activate()
    {
        //
    }

    void Move()
    {
        if(!anim.GetBool("dead"))
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y); // Geschwindigkeit auf RB übertragen
    }

    bool JumpCooledDown = true;

    void CooldownJump()
    {
        JumpCooledDown = true;
    }

    void Jump()
    {

        if (isGrounded && JumpCooledDown && !anim.GetBool("dead"))                              
        {
            rb.AddForce(Vector2.up * jumppower*rb.mass);
            JumpCooledDown = false;// Kraft nach oben auf thanos wirken
            Invoke("CooldownJump", 0.2f);
        }
    }

    

    void Blocking(bool blocking)
    {
        if (blocking)
        {
            if(ts.GetStamina() != 0f)
            {
                //ShieldRenderer.enabled = true;
                ShieldCollider.enabled = true;
                
                anim.SetBool("block", true);

                delta = Time.fixedTime - delta;

                if (delta > 1f)
                {
                    ts.DecreaseStamina(StaminaDecreaseAmountPerSecond);
                }
            }
            else
            {
                anim.SetBool("block", false);
               // ShieldRenderer.enabled = false;
                ShieldCollider.enabled = false;
            }
            
        }
        else
        {
            anim.SetBool("block", false);
            //ShieldRenderer.enabled = false;
            ShieldCollider.enabled = false;

            elsedelta = Time.fixedTime - elsedelta;

            if ((ts.GetStamina() < 100f) && (elsedelta > 1f))
            {
                ts.IncreaseStamina(StaminaIncreaseAmountPerSecond);
            }
            
        }
    }

    public void ThanosSword()
    {
        anim.SetBool("attack", true);
        MeleeCollider.enabled = true;

        StartCoroutine(NotHitting());

    }
   
    IEnumerator NotHitting()
    {
        yield return new WaitForSeconds(1f);
        
        MeleeCollider.enabled = false;
    }



    void OnDrawGizmosSelected()                    
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(LeftFoot.position, groundTriggerRadius);
        Gizmos.DrawSphere(RightFoot.position, groundTriggerRadius);
    }

    private void CheckForFlip() {

        facingLeft = (moveVector.x > 0.0f);
        facingRight = (moveVector.x < 0f);
    }

    public bool FacingLeft() { return facingLeft; }
    public bool FacingRight() { return facingRight; }

    public bool GetActivate()
    {
        return activate;
    }
   
}
