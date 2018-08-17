using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothAnimationEvent : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private EnemyStats death;

    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        death = GetComponentInParent<EnemyStats>();

        anim = GetComponent<Animator>();
        anim.SetBool("shoot", false);
    }

    public void setTriggerSloth()
    {
        anim.SetBool("shoot", true);
    }

    public void setRigidbodyActive()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    public void canBeDestroyed()
    {
        death.slothmanDeath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("canBeDestroyed", true);
    }
}