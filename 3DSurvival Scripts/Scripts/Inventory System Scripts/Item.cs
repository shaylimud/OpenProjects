using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item" , menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int value;
    public Sprite Itemicon;
    public string type;
}
