using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItem : MonoBehaviour
{

    [SerializeField] List<SlotAndItem> itemInInScene = new();
   
    public void CleanTheList()
    {
        itemInInScene.Clear();
    }
    public void SaveItemAndSlotInTheList(Item item , Slot slot)
    {
        itemInInScene.Add(new SlotAndItem(slot,item));
    }

    public List<SlotAndItem> GetAllItemFromTheList()
    {
            return itemInInScene;
    }
}

[System.Serializable]
public class SlotAndItem
{
    public Slot slot;
    public Item Item;
    public SlotAndItem(Slot slot0 ,Item item0)
    {
        slot = slot0;
        Item = item0;
    }
}