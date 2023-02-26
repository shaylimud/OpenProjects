using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Craft Item", menuName = "Craft Item/New Craft Item")]

public class CraftItem : ScriptableObject
{
    public GameObject craftItem;
    public string craftItemName;
    public int req1;
    public int req2;
}
