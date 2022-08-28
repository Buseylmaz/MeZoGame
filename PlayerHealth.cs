using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //canvaslara erişmek
using UnityEngine.SceneManagement; //Sahnelerle ilgili değişiklik yapmak için
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;//şuan ki canımız
    public float maxHealth = 100f; //max canımız
    public static PlayerHealth PH;

    public bool isDead=false;

    public Slider healthBarSlider;
    public Text healthText;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    bool isTakingDamage = false;
    public float colorSpeed = 5f;

    public FirstPersonController playerScript;

    void Awake()
    {
     PH = this;
    }

   void Start()
   {
        healthText.text = maxHealth.ToString();
        currentHealth = maxHealth;
        healthBarSlider.value = maxHealth;
   }


   void Update()
   {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
          damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSpeed * Time.deltaTime);
        }
        isTakingDamage = false;
    }

   public void DamagePlayer(float damage)
   {

        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                isTakingDamage = true;
                Dead();

            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthBarSlider.value -= damage;
                UpdateText();
            }
           
        }
   }

    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBarSlider.value = 0;
        UpdateText();
        SceneManager.LoadScene(0); //GameScene sahnesini ekleme işlemi
        playerScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void UpdateText()
    {
        healthText.text = currentHealth.ToString();
    }

}

