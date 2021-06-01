using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopSlot
{
    public Item item;
    //public int count;
    public string itemName;
    public int itemCost;

    public void Buy(ShopSlot slot)
    {
        item = slot.item;
    }
}

[CreateAssetMenu(menuName = "Data/ShopContainer")]
public class ShopItemConteiner : ScriptableObject
{
    public List<ShopSlot> slots;
}
