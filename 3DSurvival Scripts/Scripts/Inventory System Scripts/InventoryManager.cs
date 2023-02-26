using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject Inventory;
    public GameObject itemsCounterScreen;
    bool canUse;
    string itemName1;
    public Text woodAmount;
    public Text meatAmount;
    public Text appleAmount;
    public Text stoneAmount;
    string RemovedItem;
   
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        InventoryUse();
        ItemsCouner();
    }
    public void Add(Item item)
    {
        Items.Add(item);
    }
    public void Remover(Item item)
    {
        Items.Remove(item);
        RemovedItem = item.itemName;
    }
    public void ListItems()
    { 
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemName.text = item.itemName;
            itemIcon.sprite = item.Itemicon;
            itemName1 = itemName.text;
        }
    }

    void useItem() 
    { 
        foreach (var item in Items)
        {
            if(item.type == "Food")
            {
                Remover(item);
                canUse = false;
                addHunger(item.value);
                break;
            }
        }
    }
    void addHunger(int value)
    {
        PlayerVitals.hunger += value;
    }

    void InventoryUse()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeInHierarchy)
            {
                ListItems();
                Inventory.SetActive(false);
            }
            else
            {
                ListItems();
                Inventory.SetActive(true);
            }
        }
        ListItems();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            canUse = true;
            useItem();
        }
    }
    

    public void ItemsCouner ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (itemsCounterScreen.activeInHierarchy)
            {
                itemsCounterScreen.SetActive(false);
            }
            else
            {
                itemsCounterScreen.SetActive(true);
            }
        }

        int woodAmou = 0;
        int meatAmou = 0;
        int appleAmou = 0;
        int stoneAmou = 0;

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == "Wood")
            {
                woodAmou++;
            }
            if (Items[i].itemName == "Meat")
            {
                meatAmou++;
            }
            if (Items[i].itemName == "Apple")
            {
                appleAmou++;
            }
            if(Items[i].itemName == "Stone")
            {
                stoneAmou++;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && RemovedItem == "Meat")
            {
                meatAmou--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && RemovedItem == "Apple")
            {
                appleAmou--;
            }
            if(RemovedItem == "Wood")
            {
                woodAmou--;
            }
            if (RemovedItem == "Stone")
            {
                stoneAmou--;
            }
            woodAmount.text = woodAmou.ToString();
            meatAmount.text = meatAmou.ToString();
            appleAmount.text = appleAmou.ToString();
            stoneAmount.text = stoneAmou.ToString();
        }
    }
}
