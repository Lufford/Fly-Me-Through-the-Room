using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Set Health
    public int healthMax = 3;
    private int healthCurrent;

    //Sets current health to maximum at start of game
    void Start()
    {
        healthCurrent = healthMax;
    }

    //Updates health after taking damage
    public void takeDamage(int damage)
    {
        healthCurrent -= damage;
        Debug.Log("Ouch");

        //Gameover
        if (healthCurrent <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    //Add healing when health crumbs are added

    public int gethealthCurrent()
    {
        return healthCurrent;
    }
}
