using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScri : Animals
{
    public GameObject meat;
    public Item meats;
    public Transform playerTr;
    public float health = 100;
    public float maxHealth = 100;
    Animator animator;
    Vector3 selfPos, playerPos;
    float walkSpeed = 5;
    bool isAlive = true;
    float deathTimer;
    int amountOfMeat = 1;
    public AudioClip attackClip;
    public AudioSource attackSource;
    
    
    void Start()
    {
        deathTimer = 15;
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAlive)
        {
            playerPos = playerTr.position;
            selfPos = transform.position;
            moveToPlayer(selfPos, playerPos, walkSpeed);
            getDistanceFromPlayer(selfPos, playerPos);
            animationManager(animator);
            AttackSound(attackSource, attackClip, 0.8f);
           
        }
        if (health <= 0)
        {
            deathTimer -= Time.deltaTime;
            isAlive = false;
            if (deathTimer <= 0)
            {
                Destroy(gameObject);

            }
            if (amountOfMeat != 0)
            {
                InventoryManager.Instance.Add(meats);
                amountOfMeat--;
            }

            animator.SetBool("Death", true);
            deathTimer -= Time.deltaTime;
        }
    }
}
