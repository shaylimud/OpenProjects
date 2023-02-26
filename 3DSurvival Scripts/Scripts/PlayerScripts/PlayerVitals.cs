using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerVitals : MonoBehaviour
{
    public Slider HungerSlider;
    public Slider HealthSlider;
    public static float health = 100;
    public static float hunger = 100;
    float hungerLowering = 0.2f;
    float thirst;
 
    void Start()
    {
        HungerSlider.maxValue = 100;
        HealthSlider.maxValue = 100;
    }

    void Update()
    {
        TimerHungerThirst();
        UiUpdater();
        print(health);
        DeadScreen();
    }
    void UiUpdater()
    {
        HungerSlider.value = hunger;
        HealthSlider.value = health;
    }

    void TimerHungerThirst()
    {
        hunger -= Time.deltaTime * hungerLowering;
    }
    void DeadScreen()
    {
        if (HungerSlider.value == 0 || HealthSlider.value == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
