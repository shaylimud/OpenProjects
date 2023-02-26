using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class RayCast : MonoBehaviour
{
    RaycastHit hit;
    public Text hitText;
    public TextMeshProUGUI infoText;
    public Slider rayCastHealth;
    public Slider rayCastTreeSlider;
    public Slider rayCastRockSlider;
    public Slider axeHealteSlider;
    public GameObject rayCastHitHealthObject;
    public GameObject rayCastHitTree;
    public GameObject rayCastHitRock;
     AudioClip hitClip;
     AudioSource hitSource;
   



    void Start()
    {
        
    }


    void Update()
    {
        AxeDamage();


        if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
        {
            //Top Text

            if (hit.transform.tag == "Animal")
            {
                BearScri scri = hit.transform.GetComponent<BearScri>();
                hitText.text = hit.transform.tag;
                rayCastHealth.maxValue = scri.maxHealth;
                rayCastHealth.value = scri.health;
                rayCastHitHealthObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    scri.health -= 10;

                }
    
            }
            if(hit.transform.tag == "Tiger")
            {
                Tiger scri = hit.transform.GetComponent<Tiger>();
                Axe axe = GetComponent<Axe>();
                hitText.text = hit.transform.tag;
                rayCastHealth.maxValue = scri.maxHealth;
                rayCastHealth.value = scri.health;
                rayCastHitHealthObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    scri.health -= 10;
                }
            }
            if(hit.transform.tag == "Rock")
            {
                Rocks scri = hit.transform.GetComponent<Rocks>();
                {
                    hitText.text = hit.transform.tag;
                    rayCastRockSlider.maxValue = scri.maxHealth;
                    rayCastRockSlider.value = scri.health;
                    hitSource = scri.audioSourc;
                    hitClip = scri.audioClip;
                    if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerMovement.playerInRockRange)
                    {
                        scri.health -= 10;
                        if (hitSource.isPlaying == false && Axe.isActive == true)
                        {
                            hitSource.PlayOneShot(hitClip);
                        }
                    }
                    rayCastHitHealthObject.SetActive(false);
                    rayCastHitTree.SetActive(false);
                    rayCastHitRock.SetActive(true);
                }
            }
            else if (hit.transform.tag == "Tree")
            {
                hitText.text = hit.transform.tag;

                var treeScri = hit.transform.GetComponent<Trees>();
                rayCastTreeSlider.maxValue = treeScri.maxHealth;
                rayCastTreeSlider.value = treeScri.health;
                hitSource = treeScri.audioSourc;
                hitClip = treeScri.audioClip;
                if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerMovement.playerInTreeRange)
                {
                   /* hitTreeSource.PlayOneShot(hitTreeClip);*/
                    treeScri.health -= 10;
                    if(hitSource.isPlaying == false && Axe.isActive == true)
                    {
                        hitSource.PlayOneShot(hitClip);
                    }
                    
                    
                }

                rayCastHitHealthObject.SetActive(false);
                rayCastHitRock.SetActive(false);
                rayCastHitTree.SetActive(true);
            }
            else if(hit.transform.tag == "Ground"|| hit.transform.tag == null)
            {
                rayCastHitHealthObject.SetActive(false);
                rayCastHitTree.SetActive(false);
                rayCastHitRock.SetActive(false);
                hitText.text = "";
            }
            

            //InfoText
            if (hit.transform.tag == "Food")
            {
                infoText.text = "'E' to Pick up ";
            }
            else if(hit.transform.tag == "Wood")
            {
                infoText.text = "'E' to Pick up ";
            }
            else if (hit.transform.tag == "Stone")
            {
                infoText.text = "'E' to Pick up ";
            }
            else
                infoText.text = "";
            var item = hit.transform.GetComponent<ItemController>();
            if (item != null && Input.GetKeyDown(KeyCode.E))
            {
                InventoryManager.Instance.Add(item.Item);
                Destroy(hit.transform.gameObject);
            }
        }


    }

    void AxeDamage()
    {
        axeHealteSlider.maxValue = Axe.maxHealth;
        axeHealteSlider.value = Axe.Healt;

        if (Input.GetKeyDown(KeyCode.Mouse0) && hitText.transform != null && Axe.isActive == true)
        {
            Axe.Healt -= 10;
        }
    }
}
