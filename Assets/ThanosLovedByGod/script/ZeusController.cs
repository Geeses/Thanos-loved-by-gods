using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System;
using UnityEngine.UI;

public class ZeusController : MonoBehaviour
{
    public float defaultDMG;
    public float maxDMG;
    public GameObject ThunderToSpawn;
    public GameObject TornadoToSpawn;
    public GameObject StoneToSpawn;
    public Transform stoneSpawnPoint;

    public LayerMask RayCastLayer;

    public Image StaminaBar;
    private float delta;
    private float elsedelta;
    private float currStamina;
    private float maxStamina = 100f;

    public int StoneAmount = 3;
    public float cursorSpeed ;
    public float movementSpeed = 6.0f;

    private AttackController AC;
    private Transform ThunderSpawnpoint;
    private GameObject Cursor;
    private Animator anim;
    public MainMenuScritable menu;
    public AudioClip blitz;
    public AudioClip tornado;
    public AudioClip grabsound;

    //Input

    private int playerID = 1;
    private Player player;

    //Axis:
    private Vector2 moveVector;

    //CursorAxis:
    private Vector2 moveCursor;

    //Actions:
    private bool spawnThunder;
    private bool spawnThunderStartet;
    private bool spawnTornado;
    private bool spawnStone;
    private bool grab;

    //Hilfsvariablen
    private int StoneCounter = 0;
    private GameObject[] StoneArray;
    private bool entered;
    private Collider2D target;
    private Rigidbody2D rbb;
    private Rigidbody2D rba;
    private Image StoneUI;
    private Image ThunderUI;
    private Image TornadoUI;
    private float startTime;
    private float endTime;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerID);
        AC = GetComponent<AttackController>();
        Cursor = GameObject.FindGameObjectWithTag("Cursor");
        ThunderSpawnpoint = GameObject.FindGameObjectWithTag("ThunderSpawn").transform;
    }

    // Use this for initialization
    void Start()
    {
        

        rba = GetComponent<Rigidbody2D>();
        rbb = Cursor.GetComponent<Rigidbody2D>();
        StoneArray = new GameObject[StoneAmount];
        currStamina = maxStamina;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
       
        GetInput();
        ProcessInput();
    }

    private void FixedUpdate()
    {
        entered = Cursor.GetComponentInChildren<HUD_CS_CursorOver_NM_1>().GetEntered();
        target = Cursor.GetComponentInChildren<HUD_CS_CursorOver_NM_1>().GetTarget();

        CheckForGround();
    }

    private Vector2 CheckForGround()
    {
        Vector2 origin = Cursor.transform.Find("RaycastStart").transform.position;
        //Layermask bedeutet, alle angegebenen Layer werden ignoriert, wenn ~ davor steht, wird dieses NICHT ignoriert
        RaycastHit2D hit = Physics2D.Raycast(origin, -Vector2.up, Mathf.Infinity, RayCastLayer);

        if (hit && hit.collider != null)
        {
            Debug.DrawLine(Cursor.transform.Find("RaycastStart").transform.position, hit.point, Color.red, 200);
        }

        return hit.point;
    }

    void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.y = 0;

        moveCursor.x = player.GetAxis("CursorHorizontal");
        moveCursor.y = player.GetAxis("CursorVertical");

        spawnThunder = player.GetButton("SpawnThunder");
        grab = player.GetButton("Grab");

        spawnTornado = player.GetButtonDown("SpawnTornado");
        spawnStone = player.GetButtonDown("SpawnStone");
    }


    void ProcessInput()
    {
                
        Move();
        MoveCursor();
        cursorSpeed = menu.cursorspeed;

        if (grab && AC.GetAttack("Grab").IsAchieved())
        {
            AC.DoAttack("Grab");
            anim.SetBool("grabBool", true);
            
        }
        else
        {
            anim.SetBool("grabBool", false);
            ReleaseGrab();
        }

        if (spawnThunder && AC.GetAttack("SpawnThunder").IsAchieved())
        {
            // wenn gedrückt, lade X auf bis Z(float in Sekunden für MaxLoad)
            SpawnThunderStart();
        }
        else
        {
            if (spawnThunderStartet && AC.GetAttack("SpawnThunder").IsAchieved())
            {
                anim.SetBool("lightningBool", false);
                spawnThunderStartet = false;//wenn losgelassen, dann mit DamageValue (Z * kp) abschießen.
            }
        }

        if (spawnTornado && AC.GetAttack("SpawnTornado").IsCooledDown() && AC.GetAttack("SpawnTornado").IsAchieved())
        {
            anim.SetBool("tornadoBool", true);
        }
        else
        {
            anim.SetBool("tornadoBool", false);
        }

        if (spawnStone && AC.GetAttack("SpawnStone").IsCooledDown() && AC.GetAttack("SpawnStone").IsAchieved())
        {
            anim.SetBool("stoneBool", true);
        }
        else
        {
            anim.SetBool("stoneBool", false);
        }

    }

    public void SpawnLighningEvent()
    {
        spawnThunderStartet = false;
        endTime = Time.time;
        float
            dmg = (defaultDMG * (endTime - startTime) * 2f) < defaultDMG
                ? defaultDMG
                : (defaultDMG * (endTime - startTime) * 2f);

        dmg = (dmg) > maxDMG ? maxDMG : dmg;


        Vector2 FixedPosition = new Vector2(ThunderSpawnpoint.position.x, ThunderSpawnpoint.position.y - 0.3f);


        Debug.Log("dmg: " + dmg);

        var Thunder = (GameObject) Instantiate(ThunderToSpawn, FixedPosition, ThunderSpawnpoint.rotation);
        Thunder.GetComponentInChildren<DamageValue>().SetDamage(dmg);
        Debug.Log(Thunder.GetComponentInChildren<DamageValue>().GetDamage());
        
    }

    public void SpawnGrabEvent()
    {
        AC.DoAttack("Grab");
        SoundManager.instance.PlaySingle(grabsound);
    }

    public void SpawnStoneEvent()
    {
        AC.DoAttack("SpawnStone");
    }

    public void SpawnTornadoEvent()
    {
        AC.DoAttack("SpawnTornado");
        SoundManager.instance.PlaySingle(tornado);
    }

    private void SpawnThunderStart()
    {
        if (!spawnThunderStartet && AC.GetAttack("SpawnThunder").IsCooledDown())
        {
            anim.SetBool("lightningBool", true);
            spawnThunderStartet = true;
            startTime = Time.time;
        }
    }

    public void SpawnThunder()
    {
        if (spawnThunderStartet && false)
        {
            spawnThunderStartet = false;
            endTime = Time.time;
            float
                dmg = (defaultDMG * (endTime - startTime) * 2f) < defaultDMG
                    ? defaultDMG
                    : (defaultDMG * (endTime - startTime) * 2f);

            dmg = (dmg) > maxDMG ? maxDMG : dmg;


            Vector2 FixedPosition = new Vector2(ThunderSpawnpoint.position.x, ThunderSpawnpoint.position.y - 0.3f);


            Debug.Log("dmg: " + dmg);

            var Thunder = (GameObject) Instantiate(ThunderToSpawn, FixedPosition, ThunderSpawnpoint.rotation);
            Thunder.GetComponentInChildren<DamageValue>().SetDamage(dmg);
            Debug.Log(Thunder.GetComponentInChildren<DamageValue>().GetDamage());
        }
    }

    public void Grab()
    {
        if (entered && target.tag == "Movables")
        {
            //Collision abschalten
            target.transform.GetChild(0).gameObject.SetActive(false);
            target.transform.GetChild(1).gameObject.SetActive(false);
            //Cursor verfolgen
            target.attachedRigidbody.gravityScale = 0;
            target.transform.position = Cursor.transform.position;
        }
        else
        {
            if (target && target.tag == "Movables")
            {
                target.transform.GetChild(0).gameObject.SetActive(true);
                target.transform.GetChild(1).gameObject.SetActive(true);
                target.attachedRigidbody.gravityScale = 1;
            }
        }
    }

    private void ReleaseGrab()
    {
        if (target && target.tag == "Movables")

        {
            target.transform.GetChild(0).gameObject.SetActive(true);
            target.transform.GetChild(1).gameObject.SetActive(true);
            target.attachedRigidbody.gravityScale = 1;
            //Aufhören der Animation ...
            anim.SetBool("grabBool", false);
        }
    }

    public void SpawnStone()
    {
        //StartCoroutine(StoneDelay(StoneCooldown, StoneIsCooledDown));
        if (StoneCounter < StoneAmount)
        {
            StoneArray[StoneCounter] =
                Instantiate(StoneToSpawn, stoneSpawnPoint.position,
                    Quaternion.identity); // erzeugen eines Steins an der Stelle and der Zeus sich befindet
            StoneCounter++;
        }
        else
        {
            Destroy(StoneArray[0]);
            for (int i = 0; i < StoneAmount - 1; i++)
            {
                StoneArray[i] = StoneArray[i + 1];
            }

            StoneArray[StoneCounter - 1] = Instantiate(StoneToSpawn, stoneSpawnPoint.position, Quaternion.identity);
        }
    }


    public void SpawnTornado()
    {
        Quaternion noRot = new Quaternion(0, 0, 0, 1);
        Instantiate(TornadoToSpawn, new Vector2(Cursor.transform.position.x, Cursor.transform.position.y), noRot);
    }

    void Move()
    {
        rba.velocity = new Vector2(moveVector.x * movementSpeed, rba.velocity.y); // Geschwindigkeit auf RB übertragen
        anim.SetFloat("moveDirection", rba.velocity.x);
    }

    private void MoveCursor()
    {
        rbb.velocity = new Vector2(moveCursor.x * cursorSpeed + rba.velocity.x,
            moveCursor.y * cursorSpeed + rba.velocity.y); // Geschwindigkeit auf RB übertragen
    }
}