using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class EnemyHp : MonoBehaviour
{
    public int MaxHealth = 500;
    public int currentHealth;
    public Healthbar healthbar;
    void Start()
    {
        currentHealth = MaxHealth;
    }

  
 void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.tag == "PlayerWeapon")
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
