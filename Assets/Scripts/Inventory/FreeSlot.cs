using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreeSlot : Slot
{
    [SerializeField] int SlotSize;
    private void Start()
    {
        OnItemPutInSlot.AddListener(() => inventory.PutItemInSlotOutSideInventory(this));
    }

    public override void PutItemInSlot(Transform item)
    {
        base.PutItemInSlot(item);
     
    }

    // called when item in inventory
    public override void SlotClicked()
    {
        if (GetFull()) return;
        OnItemPutInSlot.Invoke();
        if (hint.HintMoed)
        {
            if (hint.HintNumber() != SlotNumber || transform.childCount == 1) return;

            hint.OnHintComplete.Invoke();
        }
    }

    public override bool GetFull()
    {
        return transform.childCount > 1;
    }
    public int GetSlotSize() { return SlotSize; }

    public override void ShowHint()
    {
       
    }
}
