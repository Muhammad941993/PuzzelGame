using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    public UnityEvent OnSelect;
    [SerializeField] Image ButtonBackGroundImage;

    public override void SlotClicked()
    {
        if (slotItem == null) return;

        if (Selected)
        {
            SlotSelected(false);
            inventory.SlotSelected();

            return;
        }
        inventory.UnSelectAllSlot();

        SlotSelected(true);

        // call to change back ground sprite
        inventory.SlotSelected();
        OnSelect.Invoke();
    }
    public void SetBackGroundImage(Sprite sprite)
    {
        ButtonBackGroundImage.sprite = sprite;
    }
    public override bool GetFull()
    {
        return transform.childCount != 0;
    }

    public override void PutItemInSlot(Transform item)
    {
        base.PutItemInSlot(item);
    }

}
