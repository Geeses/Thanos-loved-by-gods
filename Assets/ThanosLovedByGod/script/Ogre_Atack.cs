using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre_Atack : MonoBehaviour {

    bool inRange = false;
    public Character Ogre;
    public bool hot = false;
    public Collider2D DamageCollider;
    public bool attackingCooldown;
    public bool attacking;
    
    private Collider2D tempColl;
    private Smorc smorc;

    private void Start()
    {
        smorc = GetComponentInParent<Smorc>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Thanos") && !attackingCooldown)
        {
            Attack();
        }
        
    }

    private void Attack()
    {
        attacking = true;
        StartCoroutine(attackCooldown(smorc.character.CooldownTime));
    }
    

    IEnumerator attackCooldown(float DelayTime)
    {
        attackingCooldown = true;
        
        yield return new WaitForSeconds(DelayTime);

        attackingCooldown = false;
    }

}
