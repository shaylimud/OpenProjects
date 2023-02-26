using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class Trees : MonoBehaviour
{
    public GameObject Wood;
    public GameObject apple;
    public float health = 100;
    public float maxHealth = 100;
    public AudioSource audioSourc;
    public AudioClip audioClip;
    Vector3 startPos;

    void Start()
    {  
        startPos = transform.position;
    }

    void Update()
    {
        if (health <= 0)
        {
            Instantiate(Wood, transform.position = new Vector3(transform.position.x, transform.position.y - 0.5F, transform.position.z), Wood.transform.rotation);

            for (int i = 0; i < 4; i++)
            {
                Instantiate(apple, transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), apple.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
