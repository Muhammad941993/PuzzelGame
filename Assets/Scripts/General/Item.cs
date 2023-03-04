using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityEvent OnItemSelected;
    public UnityEvent OnItemDeSelected;

    [SerializeField] Transform StartSlot;
   // public GameObject HintObject;
    RectTransform Button_RectTransform;
   //  public Button button { set; get; }
    [SerializeField] int ItemSize;
    public bool Selected { get; set; }
    private void Start()
    {
       // button = GetComponent<Button>();
        Button_RectTransform = gameObject.GetComponent<RectTransform>();
    }
    public void ResetItemScaleAndSize()
    {

        Button_RectTransform.offsetMin = new Vector2(0, Button_RectTransform.offsetMin.y);

        Button_RectTransform.offsetMax = new Vector2(0, Button_RectTransform.offsetMax.y);

        Button_RectTransform.offsetMax = new Vector2(Button_RectTransform.offsetMax.x, 0);

        Button_RectTransform.offsetMin = new Vector2(Button_RectTransform.offsetMin.x, 0);

        Button_RectTransform.localScale = new Vector3(1, 1, 1);
        
    }
    public void PutItemIn()
    {
       // button.enabled = false;
        ResetItemScaleAndSize();
    }

 //   public void ItemInteractable(bool interactable) { button.enabled = interactable; }
    
    public int GetItemSize() { return ItemSize; }

  
    public void ResetItemInStartPos()
    {
        this.transform.SetParent(StartSlot);
        transform.SetAsFirstSibling();
      //  button.enabled = true;
        Selected = false;
        ResetItemScaleAndSize();

    }
}
