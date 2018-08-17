using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Character CharacterAsset;

    //HUD elements
    public Text Name;
    public Image Ten;
    public Image Twenty;
    public Image Thirty;
    public Image Fourty;
    public Image Fifty;
    public Image Sixty;
    public Image Seventy;
    public Image Eighty;
    public Image Ninety;
    public Image Hundred;

    public Image StaminaBar;
    public Image HealthBar;

    //Gameplay Stats
    private float maxHealth;
    private float currentHealth;
    private float checkhealth;

    //Thanosonly
    private float maxStamina;
    private float currentStamina;


    private Color EndColor = new Color(0, 0, 0, 196);
    private Color StartColor = new Color(20, 100, 240, 190);


    void Start()
    {
        
        //checkhealth = currentHealth;
        Name.text = CharacterAsset.name;

        maxHealth = CharacterAsset.health; // Zu Beginn noch volles Leben. Nur einmalige Zuweisung
        currentHealth = maxHealth;

        //Wenn Thanos dann:
        if (Ten)
        {
            SetHealthbar();
        }

        //sonst für Gegner:
        else
        {
            HealthBar.fillAmount = currentHealth / maxHealth;
        }

        if (StaminaBar)
        {
            maxStamina = CharacterAsset.stamina;
            currentStamina = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Ten)
        {
            SetHealthbar();
        }

        //sonst für Gegner:
        else
        {
            HealthBar.fillAmount = currentHealth / maxHealth;
        }

        //Um nicht jedes FixedUpdate diese ewige Methode durchlaufen zu lassen.
        checkhealth = currentHealth;

        if (StaminaBar) SetStaminaBar();
        //Im FixedUpdate wird dann der aktuelle wert durch den maximalen Wert dividiert
    }

    void SetStaminaBar()
    {

        StaminaBar.fillAmount = currentStamina / maxStamina;

        float lerp = StaminaBar.fillAmount * 0.05f;

        StaminaBar.color = Color.Lerp(EndColor, StartColor, lerp);
    }

    public void SetCurrentHealth(float health)
    {
        currentHealth = health;

    }

    public void SetCurrentStamina(float stamina)
    {
        currentStamina = stamina;
    }

    private void SetHealthbar()
    {
        Ten.gameObject.SetActive(false);
        Twenty.gameObject.SetActive(false);
        Thirty.gameObject.SetActive(false);
        Fourty.gameObject.SetActive(false);
        Fifty.gameObject.SetActive(false);
        Sixty.gameObject.SetActive(false);
        Seventy.gameObject.SetActive(false);
        Eighty.gameObject.SetActive(false);
        Ninety.gameObject.SetActive(false);
        Hundred.gameObject.SetActive(false);

        if (currentHealth > 0)
        {
            Ten.gameObject.SetActive(true);

            if (currentHealth > 10)
            {
                Ten.gameObject.SetActive(false);
                Twenty.gameObject.SetActive(true);

                if (currentHealth > 20)
                {
                    Thirty.gameObject.SetActive(true);

                    if (currentHealth > 30)
                    {
                        Thirty.gameObject.SetActive(false);
                        Fourty.gameObject.SetActive(true);

                        if (currentHealth > 40)
                        {
                            Fifty.gameObject.SetActive(true);

                            if (currentHealth > 50)
                            {
                                Fifty.gameObject.SetActive(false);
                                Sixty.gameObject.SetActive(true);

                                if (currentHealth > 60)
                                {
                                    Seventy.gameObject.SetActive(true);

                                    if (currentHealth > 70)
                                    {
                                        Seventy.gameObject.SetActive(false);
                                        Eighty.gameObject.SetActive(true);

                                        if (currentHealth > 80)
                                        {
                                            Ninety.gameObject.SetActive(true);

                                            if (currentHealth > 90)
                                            {
                                                Ninety.gameObject.SetActive(false);
                                                Hundred.gameObject.SetActive(true);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }        
    }
}

