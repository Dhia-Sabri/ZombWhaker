using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class EnemyHp : MonoBehaviour
{
    public int MaxHealth = 500;
    public int currentHealth;
    public Transform me;    
    void Awake()
    {
        currentHealth = MaxHealth;
        me = GetComponent<Transform>();
    }

    private void Update()
    {
        Death();
    }


    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "PlayerWeapon")
      { 
         TakeDamage(30);
      }
    }
       
    
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }   
    
    void Death()
    {
        if (currentHealth <= 0)
        {
            Destroy(me.gameObject);
        }
    }
}
