using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThanosStats : MonoBehaviour
{
    public Character thanos;

    private float maxHealth;
    private float currHealth;
    private float maxStamina;
    private float currStamina;
    private Animator anim;

    private float movementSpeed;
    private float jumpPower;
    private float damage;
    private Rigidbody2D rb;
    // Rest Flo
    public Text Hitpoints;
    //time until restart after death
    public float time = 3f;
    public AudioClip DmgThanos;
    

    private void Start()
    {
        maxHealth = thanos.health;
        maxStamina = thanos.stamina;
        currHealth = maxHealth;
        currStamina = 0f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        if (time == 0)
            time = 3f;
    }

    public void DealDmgToThanos(float dmg, float knockback)
    {             
        currHealth -= dmg;
        GetComponent<UIController>().SetCurrentHealth(currHealth);
        rb.velocity = new Vector2(knockback, 0f);
        SoundManager.instance.PlaySingle(DmgThanos);

        if (currHealth <= 0)
        {
            anim.SetBool("dead", true);
            StartCoroutine(waitTillAnimation(time));
        }
    }

    public void DecreaseStamina(float amount)
    {
        currStamina -= amount;
        currStamina = (currStamina<0f)?0f:currStamina;
        GetComponent<UIController>().SetCurrentStamina(currStamina);
    }

    public void IncreaseStamina(float amount)
    {
        currStamina += amount;
        currStamina = (currStamina > 100f) ? 100f : currStamina;
        GetComponent<UIController>().SetCurrentStamina(currStamina);
    }

    public float GetStamina() { return currStamina; }

    private IEnumerator waitTillAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

