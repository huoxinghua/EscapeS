using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 1;
    }

   void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0) ;
            //we are dead
            // play dead animation
            anim.SetBool("IsDead" , true);
            // show gameOver scene 
    }


    public void Heal (int amount)
    {
        currentHealth += amount;

        if (currentHealth < maxHealth) ;
        {
            currentHealth = maxHealth ;
        }
    }

}
