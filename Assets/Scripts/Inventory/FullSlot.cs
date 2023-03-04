using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSlot : Slot
{
    [SerializeField] Item item;

    private void Start()
    {
        slotItem = item;
        OnItemRemoveFromSlot.AddListener (() => RemoveItemFromSlot());
    }

    public override void SlotClicked() 
    {
        if (hint.HintMoed)
        {
            if (hint.HintNumber() != SlotNumber) return;

            hint.OnHintComplete.Invoke();
        }

      
        OnItemRemoveFromSlot.Invoke();
      
    }

    public override void PutItemInSlot(Transform item)
    {
        base.PutItemInSlot(item);
    }
    void RemoveItemFromSlot()
    {
        inventory.PutItemInInventory(item.transform);
        slotItem = null;
    }
}
