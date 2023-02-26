using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject rock;
    public float health;
    public float maxHealth;
    public AudioSource audioSourc;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if(transform.localScale == new Vector3(2, 2, 2))
            {
                maxHealth = 100;
                Instantiate(rock, transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), rock.transform.rotation);
                Instantiate(rock, transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z), rock.transform.rotation);
                Instantiate(rock, transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z), rock.transform.rotation);
                Destroy(gameObject);
            }
            else if(transform.localScale == new Vector3(1,1,1))
            {
                maxHealth = 50;
                Instantiate(rock, transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), rock.transform.rotation);
                Destroy(gameObject);
            }
          
          
        }
    }
}
