using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Slot : MonoBehaviour 
{
    protected Hint hint;
    protected MInventory inventory;
    [SerializeField]public int SlotNumber = -1;
    public Button slotButton { set; get; }
    public Item slotItem { get; set; }
    public bool Selected{ get; set; }
    public UnityEvent OnItemPutInSlot;
    public UnityEvent OnItemRemoveFromSlot;
    public UnityEvent OnSlotFinishJop;

    public virtual void Awake()
    {
        hint = FindObjectOfType<Hint>();
        inventory = FindObjectOfType<MInventory>();
        slotButton = GetComponent<Button>();

        hint.OnHintModeOn.AddListener(()=> { ResetSlot(); });
        slotButton.onClick.AddListener(()=>{ SlotClicked(); });

        
    }
    public virtual void PutItemInSlot(Transform item)
    {
        slotItem = item.GetComponent<Item>();
        item.SetParent(transform);
        slotItem.PutItemIn();
    }

    //public virtual void SuccesfulItemTransport() { }

    // called when item in inventory
    public virtual void SlotClicked() {  }
   

    public virtual void SlotSelected(bool selected)
    {
        if (slotItem == null) return;

        Selected = selected;
        slotItem.Selected = selected;
    }

    public virtual bool GetFull() { return false; }
   
    public Item GetSelectedItem() { return slotItem; }

    public virtual void ResetSlot()
    {
        Selected = false;
        if (slotItem == null) return;
        slotItem.ResetItemInStartPos();
    }

    public virtual void ShowHint()
    {
      
    }
}
