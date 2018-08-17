using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageValue : MonoBehaviour
{
    public Character enemy;
    public Attack_ScriptableObject AO;

    
    public float DamageAmountWithoutEnemy; //Der individuelle Wert für jeden DamageDealer
    [HideInInspector]
    public float CooldownTime = 0f;
    private float knockback;
    private bool enemyDamaging = false;
    private bool trapDamaging = false;
    private bool grounded = false;
    private bool canDamage = true;
    private bool doUpdate = false;
    private Vector3 lastpos;
    private string Multiplier;
    private bool attacked = false;
    private Transform tf;
    private bool DoNotUpdateDmg;

    public bool IsAttacking()
    {
        return attacked;

    }

    public void SetGrounded(bool Grounded)
    {
        grounded = Grounded;
    }

    private void Update()
    {
        if (enemy)
        {
            DamageAmountWithoutEnemy = enemy.attackDamage;
            CooldownTime = enemy.CooldownTime;
            knockback = enemy.knockback;
        }
        else if (AO)
        {
            if(!DoNotUpdateDmg) DamageAmountWithoutEnemy = AO.Damage;
            CooldownTime = AO.CooldownTime;
            knockback = AO.knockback;
        }
    }

    public void SetDamage(float dmg)
    {
        DamageAmountWithoutEnemy = dmg;
        DoNotUpdateDmg = true;

    }

    private void Start()
    {
     
    }

    public float GetDamage() { return DamageAmountWithoutEnemy; }

    // Use this for initialization
    void Awake()
    {
        if (enemy)
        {
            DamageAmountWithoutEnemy = enemy.attackDamage;
            CooldownTime = enemy.CooldownTime;
            knockback = enemy.knockback;
        }
        else if (AO)
        {
            DamageAmountWithoutEnemy = AO.Damage;

            CooldownTime = AO.CooldownTime;
            knockback = AO.knockback;
        }
        //falling State
        lastpos = transform.position;

        //Taggen des Auslösers/DamageDealers
        string tag = this.gameObject.tag;

        switch (tag)
        {
            case "Stone":
                doUpdate = true;
                //gehe in die Schleife, für denn Fall-state

                Multiplier = tag;
                break;
            case "Thunder":
                Multiplier = tag;
                DoNotUpdateDmg = true;
                //Platz für individuelle Schadensabfrage
                ;
                break;
            case "ThanosSword":
                Multiplier = tag; 
                //Platz für individuelle Schadensabfrage
                ;
                break;
            case "Enemy":
                //Platz für individuelle Schadensabfrage
                enemyDamaging = true;
                break;
            case "Arrow":
                //Platz für individuelle Schadensabfrage
                enemyDamaging = true;
                break;
            case "SpikeTrap":
                //Platz für individuelle Schadensabfrage
                trapDamaging = true;
                break;

        }



    }

    private void FixedUpdate()
    {


        //nur wenn DamageDealer "Stone" ist.
        if (doUpdate)
        {
            //bewegt sich das GO?
            bool moving = !(transform.position == lastpos);
            
            //update für movement
            lastpos = transform.position;

            //nur wenn bewegung & nicht auf dem Boden
            bool falling = (moving && !grounded);

            //Stein macht nur Schaden, wenn er fällt.
            if (falling) { 
                canDamage = true;
                //Debug.Log("can Damage");
            }
            else 
            {
                canDamage = false;
                //Debug.Log("cannot Damage");
            }
        }
    }


    //DamageDealer-Methoden


        //Dmg to Enemy, wenn DamageDealer Thunder,Stone oder Thanos ist
    private void DealDamageToEnemy(Collider2D collision, string multiplier, float damage)
    {
        float kb = ((collision.transform.position.x - this.transform.position.x)<0)?-1f:1f;
        kb *= knockback;
        collision.gameObject.GetComponent<EnemyStats>().DealDmgToEnemy(multiplier, damage, kb);

    }

        //Dmg to Thanos, wenn DamageDealer ein Gegner ist
    private void DealDamageToThanos(Collider2D collision, float damage)
    {
        float kb = ((collision.transform.position.x - this.transform.position.x) < 0) ? -1f : 1f;
        kb *= knockback;
        collision.gameObject.GetComponent<ThanosStats>().DealDmgToThanos(damage,0);

    }

    public void ResetAttacked()
    {
        attacked = false;

    }

    //Collisions:

    //Für den grounded-State

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!enemyDamaging || trapDamaging) //nur wenn der Player angreift
        {
            switch (collision.tag)
            {

                case "Destructables":
                    // if (canDamage)
                    ;
                    break;
                case "Gegner":
                    if (canDamage) DealDamageToEnemy(collision, Multiplier, DamageAmountWithoutEnemy);
                    break;

            }
        }

        // wenn der Gegner angreift
        if (enemyDamaging || trapDamaging)
        {

            switch (collision.tag)
            {
                case "Thanos":
                    if (canDamage && !attacked)
                    {
                        DealDamageToThanos(collision, DamageAmountWithoutEnemy);
                        attacked = true;
                        Invoke("ResetAttacked", CooldownTime);
                    }

                    break;
                case "Destructables":
                    // if (canDamage)
                    ;
                    break;

            }

        }
    }
    //Collisionsabfrage bei Angriffen
    
}
