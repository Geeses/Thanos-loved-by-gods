using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothAttack : MonoBehaviour
{

    public Character character;
    public Transform bow;
    public GameObject arrow;
    
    private float attackCD = 2f; // attack cooldown
    private Animator anim;
    

   // private Transform player;
    //private SpriteRenderer SlothSprite;
    private float timeBuffer = 0; // attack timer
 
    private Camera triggercam;




    private void Start()
    {
        
        anim = GetComponentInChildren<Animator>();
        triggercam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        anim.SetBool("isAttacking", false);
        anim.SetFloat("attackspeed", character.attackSpeed);
    }

    private void Update()
    {
        Shoot();
    }
    
    public void Shoot()
    {
        attackCD = 1f / character.attackSpeed;

        Vector3 screenPoint = triggercam.WorldToViewportPoint(transform.position); // wenn gegner in die Kamera läuft
        bool onScreen = screenPoint.z >= 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // bool der guckt wo der Gegner ist im Vergleich zur Kamera

        if (onScreen)
        {            
            anim.SetBool("isAttacking", true);
            if (((Time.time - timeBuffer) > attackCD) && anim.GetBool("shoot"))
            {
                
                Instantiate(arrow, bow.position, bow.rotation);
                
                timeBuffer = Time.time;
                
                anim.SetBool("shoot", false);
            }
        }
        if(!onScreen)
            anim.SetBool("isAttacking", false);
    }

}
