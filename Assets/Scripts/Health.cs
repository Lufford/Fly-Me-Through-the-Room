using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Set Health
    public int healthMax = 3;
    private int healthCurrent;
    private bool canBeHurt;

    private SpriteRenderer sr;

    //Sets current health to maximum at start of game
    void Start()
    {
        healthCurrent = healthMax;
        canBeHurt = true;
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("blink", 0f, 0.1f);
    }

    private void blink()
    {
        if (sr.enabled && !canBeHurt)
        {
            sr.enabled = false;
        }
        else if (!canBeHurt)
        {
            sr.enabled = true;
        }
    }

    //Updates health after taking damage
    public void takeDamage(int damage)
    {
        StartCoroutine(DamageCooldown(damage));

        //Gameover
        if (healthCurrent <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private IEnumerator DamageCooldown(int damage)
    {
        if (canBeHurt)
        {
            canBeHurt = false;
            healthCurrent -= damage;
            Debug.Log("Ouch");
            yield return new WaitForSeconds(2f);
            canBeHurt = true;
            sr.enabled = true;
        }
    }

    //Add healing when health crumbs are added

    public int gethealthCurrent()
    {
        return healthCurrent;
    }
}
