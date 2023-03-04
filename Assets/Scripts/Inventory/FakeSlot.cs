using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSlot : Slot
{
    public override void PutItemInSlot(Transform item)
    {
        base.PutItemInSlot(item);
        OnItemPutInSlot.Invoke();
    }
}
