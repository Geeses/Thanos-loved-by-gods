using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Character character;

    private float maxHealth;
    private float currHealth;

    //private float attackDmg;
    //private float movementSpeed;

    public GameObject kfcBucket;

    //Individualisierung der Prefabs
    public int stoneDmgMultiplier = 1;
    public int thanosDmgMultiplier = 1;
    public int thunderDmgMultiplier = 1;
    private Rigidbody2D rb;
    private float knockback;
    private Animator anim;
    public AudioClip EnemyDmg;


    private void Start()
    {
        //Zuweisung über Scriptables;
        maxHealth = character.health;
        //attackDmg = character.attackDamage;
        //movementSpeed = character.movementSpeed;
        //knockback = character.knockback;

        //Zuweisung der Startgesundheit
        currHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        /*
         * Da alle Skripte auf jedem Charakter reingezogen sind wie man Lust hat, schau ich hier einfach überall nach
         * wo der Animator sein könnte ...
         */

        anim = GetComponent<Animator>();

        if (anim == null)
            anim = GetComponentInChildren<Animator>();
        if (anim == null)
            anim = GetComponentInParent<Animator>();
    }


    public void DealDmgToEnemy(string Multiplier, float dmg, float knockback)
    {
        float multi = 1f;

        switch (Multiplier)
        {
            case "Stone":
                multi = stoneDmgMultiplier;
                break;
            case "Thunder":
                multi = thunderDmgMultiplier;
                break;
            case "ThanosSword":
                multi = thanosDmgMultiplier;
                break;
        }

        currHealth -= dmg * multi;
        GetComponent<UIController>().SetCurrentHealth(currHealth);
        SoundManager.instance.PlaySingle(EnemyDmg);

        if (gameObject.GetComponent<Rigidbody2D>() == true)
        {
            rb.velocity = new Vector2(knockback, 0f);
        }

        if (currHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        /*
         * Abfrage ob der Enemy vielleicht falsch benannt wurde, wenn ja gibt er einen Hinweis raus, dass man den
         * character.name richtig benennen sollte.
         */

        if (character.name != "Chickenman" && character.name != "Ogre" && character.name != "Slothman")
        {
            Debug.Log(
                "Gegner wurden in falsche Namen umbenannt, bitte wieder auf Chickenman, Ogre oder Slothman ändern.");
        }

        chickenmanDeath();
        ogreDeath();
        slothmanDeath();
    }

    /*
     * Methode zum überprüfen, ob es der Chickenman ist.
     * Dann wird der Bucket am Transform vom "Root" gespawned.
     * Das spawnen am obersten Objekt funktioniert nicht, da dieser sich nicht mitbewegt.
     */

    private void chickenmanDeath()
    {
        if (character.name == "Chickenman")
        {
            //Sterbebucket wird gespawned
            if (kfcBucket != null)
            {
                Instantiate(kfcBucket, gameObject.transform.position, gameObject.transform.rotation);
            }
            else
            {
                Debug.Log(
                    "KFC-Bucket wurde nicht zugewiesen. Unter Chickenman > Root For Flip bei EnemyStats.cs findet die Zuweisung statt.");
            }

            //Chickenmanobjekt wird zerstört
            GameObject parent = transform.parent.gameObject;
            Destroy(parent);
        }
    }

    /*
     * Template für die restlichen Implementationsmethoden
     */

    private void ogreDeath()
    {
        if (character.name == "Ogre")
        {
            anim.SetBool("dead", true);

        }
    }

    public void ogreDisappear()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
    
    /*
     * Für den Slothman Deathübergang hab ich sehr viel mit Animationevents gearbeitet, die Events sind in dem Skript
     * SlotAnimationEvent.cs beschrieben uns sind bei "Sloth"
     * Am Ende wird eine eigene "Animation" ausgelöst wenn er irgendwas beim fallen berührt, welche einfahc nur nen bool
     * "canBeDestroyed" auf true setzt, durch ein AnimationEvent, was anderes hat die Animation nicht.
     */

    public void slothmanDeath()
    {
        if (character.name == "Slothman")
        {
            /*
             * Insert Zeug was vor dem Tod geschehen soll hier :)
             */
            anim.SetBool("die", true);
            
            if (anim.GetBool("canBeDestroyed"))
            {
                /*
                 * hier ist der Sloth am verschwinden, hier kann man die Effekte einfügen
                 */
                
                GameObject parent = transform.parent.gameObject;
                Destroy(parent);
            }
        }
    }

}