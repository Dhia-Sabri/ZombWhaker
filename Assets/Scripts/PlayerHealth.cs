using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 500;
    public int currentHealth;
    public Healthbar healthbar;
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {

        /* ki bch ymiss l enemy weapon wala li howa
          void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "weapon x")
            {
                TakeDamage(30);
                if (currentHealth <= 0)
                {
                    Die(); 
                }
            }
        }
         */
        //testing health bar & damage 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    void Die()
    {

    }
}
