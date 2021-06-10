using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class shopItemSlot
{
    public Item item;
    public string name;
    public int cost;

    public void Copy(shopItemSlot slot)
    {
        item = slot.item;
        name = slot.name;
        cost = slot.cost;
    }

    public void Set(Item item, string count, int cost)
    {
        this.item = item;
        this.name = count;
        this.cost = cost;
    }

    public void Clear()
    {
        item = null;
        name = "";
        cost = 0;
    }
}

[CreateAssetMenu(menuName = "Data/ShopContainer")]
public class shopContainer : ScriptableObject
{
    public List<shopItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        //if (item.stackable == true)
        //{
        //    ItemSlot itemSlot = slots.Find(x => x.item == item);
        //    if (itemSlot != null)
        //    {
        //        itemSlot.count += count;
        //    }
        //    else
        //    {
        //        itemSlot = slots.Find(x => x.item == null);
        //        if (itemSlot != null)
        //        {
        //            itemSlot.item = item;
        //            itemSlot.count = count;
        //        }
        //    }
        //}
        //else
        ////add non stackable item to ours container
        //{
        //    ItemSlot itemSlot = slots.Find(x => x.item == null);
        //    if (itemSlot != null)
        //    {
        //        itemSlot.item = item;
        //    }
        //}
    }

    public void Remove(Item itemToRemove, int count = 1)
    {
        //if (itemToRemove.stackable)
        //{
        //    ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
        //    if (itemSlot == null) { return; }

        //    itemSlot.count -= count;
        //    if (itemSlot.count <= 0)
        //    {
        //        itemSlot.Clear();
        //    }
        //}
        //else
        //{
        //    while (count > 0)
        //    {
        //        count -= 1;

        //        ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
        //        if (itemSlot == null) { return; }

        //        itemSlot.Clear();
        //    }
        //}
    }
}
