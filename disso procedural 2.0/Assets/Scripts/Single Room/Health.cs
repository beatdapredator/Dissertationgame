using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject healthBar;
    public float maxHealth;
    public float healthValue = 3;
    public bool destroyonDeath;
    public bool sendtoloseScreen;
    public bool sendtowinScreen;


    public void Heal()
    {

        if (healthValue < maxHealth)
        {
            healthValue = healthValue + 1;
        }
        else if (healthValue == maxHealth)
        {
            healthValue = healthValue + 1;
            maxHealth = maxHealth + 1;
        }
        float healthPercentage;
        healthPercentage = healthValue / maxHealth;
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector2(healthPercentage, 1);
        }
    }
    void HealthReduction()
    {
        float healthPercentage;
        healthValue = healthValue - 1;
        healthPercentage = healthValue / maxHealth;
        if(healthBar != null)
        {
            healthBar.transform.localScale = new Vector2(healthPercentage, 1);
        }


        if (healthValue <= 0)
        {
            if (destroyonDeath == true)
            {
                Destroy(this.gameObject);
            }
            else if(sendtoloseScreen == true)
            {
                SceneManager.LoadScene("scenes/Loss Screen");
            }
            else if(sendtowinScreen == true)
            {
                SceneManager.LoadScene("scenes/Win Screen");
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            HealthReduction();
        }
    }
}
