using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public int maxHealt;
    public int enemyDamage;
    public int currentHealth;


    public EnemyClass(int maxHealt, int currentHealt)
    {
        this.maxHealt = maxHealt;
        this.currentHealth = currentHealt;

    }

    public EnemyClass(int maxHealt, int enemyDamage, int currentHealt)
    {
        this.maxHealt = maxHealt;
        this.enemyDamage = enemyDamage;
        this.currentHealth = currentHealt;
      
    }


    private void Update()
    {
        
    }

    
}
