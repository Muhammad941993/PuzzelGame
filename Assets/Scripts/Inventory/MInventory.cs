using System.Collections.Generic;
using UnityEngine;


public class MInventory : MonoBehaviour
{
    [SerializeField] List<InventorySlot> inventorySlots;
    Hint hint;
    [SerializeField] SaveItem saveItem;
    [SerializeField] Sprite[] ButtonSprite = new Sprite[2];
    enum ImageType { UnSelectedSlot = 0, SelectedSlot = 1 }

    public Item selectedItem { set; get; }
    public InventorySlot selectedSlot { set; get; }
    public bool SuccesfulPutInSlot { set; get; }

    private void Awake()
    {
        hint = FindObjectOfType<Hint>();
    }
    private void Start()
    {
        hint.OnHintModeOn.AddListener(() => OnHintModeOn());
        hint.OnHintModeOff.AddListener(() => OnHintModeOff());
    }

    public void PutItemInInventory(Transform item)
    {

        SuccesfulPutInSlot = false;
        foreach (InventorySlot slot in inventorySlots)
        {
            // if (hint.HintMoed && !item.GetComponent<Item>().HintObject.activeSelf) return;
            if (!slot.GetFull())
            {
                slot.PutItemInSlot(item);
                SuccesfulPutInSlot = true;
                break;
            }
        }

    }



    public bool FullInventory()
    {
        int SlotCount = 0;

        foreach (Slot slot in inventorySlots)
        {
            if (slot.GetFull())
            {
                SlotCount++;
            }
        }

        if (SlotCount == inventorySlots.Count)
            return true;
        else return false;
    }
    public void SlotSelected()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.Selected)
            {
                InventorySlotSelected(slot);
               
            }
            else
            {
                UnSelectInventorySlot(slot);
            }
        }

    }

    public void SpecialSlotSelected()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (!slot.GetFull())
            {
                slot.slotItem = null;
            }
        }
    }
    void InventorySlotSelected(InventorySlot slot)
    {
        slot.SetBackGroundImage(BackGroundImageType(ImageType.SelectedSlot));
        selectedItem = slot.GetSelectedItem();
        selectedItem.OnItemSelected.Invoke();
        selectedSlot = slot;
    }
    void UnSelectInventorySlot(InventorySlot slot)
    {
        slot.SetBackGroundImage(BackGroundImageType(ImageType.UnSelectedSlot));
        slot.SlotSelected(false);

        if (slot.slotItem == null) return;
        slot.slotItem.OnItemDeSelected.Invoke();

    }

    public void UnSelectAllSlot()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.SlotSelected(false);
        }
    }

    public void RemoveItemFromSlot()
    {
        UnSelectAllSlot();
        SpecialSlotSelected();
        SlotSelected();
    }
    Sprite BackGroundImageType(ImageType image)
    {
        if (image == ImageType.SelectedSlot)
        {
            return ButtonSprite[1];
        }
        else
        {
            return ButtonSprite[0];
        }
    }



    public void PutItemInSlotOutSideInventory(FreeSlot slot)
    {
        if (selectedItem == null) return;

        if (selectedItem.GetItemSize() != slot.GetSlotSize()) return;

        slot.PutItemInSlot(selectedItem.transform);
        slot.OnSlotFinishJop.Invoke();
        UnSelectInventorySlot(selectedSlot);
        //selectedSlot.SetBackGroundImage(BackGroundImageType(ImageType.UnSelectedSlot));
        selectedSlot.slotItem = null;
        selectedItem = null;

    }

    void SaveItemFromInventorySlot()
    {
        var slotlist = FindObjectsOfType<Slot>();
        foreach (Slot slot in slotlist)
        {
            if (slot.slotItem == null) continue;

            saveItem.SaveItemAndSlotInTheList(slot.slotItem, slot);
        }

    }

    void GetSavedItemToInventory()
    {
        var item = saveItem.GetAllItemFromTheList();

        foreach (SlotAndItem slotitem in item)
        {
            slotitem.slot.PutItemInSlot(slotitem.Item.transform);
        }
    }
    public void OnHintModeOn()
    {
        SaveItemFromInventorySlot();
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.GetFull())
            {
                slot.ResetSlot();
            }
        }
    }


    public void OnHintModeOff()
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.transform.childCount != 0)
            {
                slot.ResetSlot();
            }
        }
        GetSavedItemToInventory();
        saveItem.CleanTheList();


        UnSelectAllSlot();
        SlotSelected();
    }
}


