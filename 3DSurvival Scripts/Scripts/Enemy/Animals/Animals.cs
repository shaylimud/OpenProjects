using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class Animals : MonoBehaviour
{
    public float distanceFromPlayer;
    public float attackTimer = 2f;
    public bool isSearching = false;
    public bool isWalking = false;
    public bool isAttacking = false;

    public void moveToPlayer(Vector3 selfPos, Vector3 playerPos , float walkSpeed)
    {
        if (distanceFromPlayer >= 3 && distanceFromPlayer <= 10)
        {
            transform.position = Vector3.MoveTowards(selfPos, playerPos, walkSpeed * Time.deltaTime);
            transform.LookAt(playerPos);
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (distanceFromPlayer < 3)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    
        if (isAttacking)
        {
            Attacking();
        }
    }
    public void getDistanceFromPlayer(Vector3 selfPos , Vector3 playerPos)
    {
        distanceFromPlayer = Vector3.Distance(selfPos, playerPos);    
    }
    
    public void animationManager(Animator animator)
    {
        if (isWalking)
        {
            animator.SetBool("Walk", true);

        }
        else
            animator.SetBool("Walk", false);

        if (isAttacking)
        {
            animator.SetBool("Attack", true);
        }
        else
            animator.SetBool("Attack", false);

    }
    public void Attacking()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            PlayerVitals.health -= 10;
            attackTimer = 2f;
            print(PlayerVitals.health);
        }
    }

    public void AttackSound(AudioSource audioSource, AudioClip audioClip, float delayTime)
    {
       
        if (isAttacking && audioSource.isPlaying == false)
        {
            audioSource.PlayDelayed(delayTime);
        }
        if(isAttacking == false)
        {
            audioSource.Stop();
        }
    }
}
