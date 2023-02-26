using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MonoBehaviour
{
    public GameObject axeHealteBar;

    public static float Healt = 500;
    public static float maxHealth = 500;
    public static bool isActive;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Healt <= 0)
        {
            gameObject.SetActive(false);
            axeHealteBar.SetActive(false);
            isActive = false;
        }
        else
        {
            gameObject.SetActive(true);
            axeHealteBar.SetActive(true);
            isActive = true;
        }
    }
}
