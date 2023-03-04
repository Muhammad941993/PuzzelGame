using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMovement : MonoBehaviour
{
    bool Move = false;
    [SerializeField] float Speed = 1;
    [SerializeField] float TopPoint;
    [SerializeField] float BottonPoint;

    [SerializeField] float CorrectUp;
    [SerializeField] float CorrectDown;
    RectTransform rectTransform;

   [SerializeField] bool correctPos = false;
    [SerializeField] Hint hint;
    Button button;

    float lastPos ;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!Move) return;

        if (rectTransform.localPosition.y > TopPoint)
            Speed *= -1;

        if (rectTransform.localPosition.y < BottonPoint)
            Speed *= -1;


        rectTransform.localPosition += Vector3.up * Time.deltaTime * Speed;
    }
    void Update()
    {
       
    }

    public void ToggelMovement()
    {
        Move = !Move;

        if (rectTransform.localPosition.y > CorrectDown && rectTransform.localPosition.y < CorrectUp)
        {
            correctPos = true;
            button.interactable = false;

            if(hint.HintMoed)
            hint.OnHintComplete.Invoke();
        }
        else
        {
            correctPos = false;
        }
            
    }

   public bool CorrectPosition() { return correctPos; }

    public void WhenHintModeOn()
    {
        lastPos = rectTransform.position.y;
        if (correctPos)
        {
            hint.OnHintComplete.Invoke();
        }
        //StartCoroutine(DelayHintComplete());
            
    }

    IEnumerator DelayHintComplete()
    {
        yield return new WaitForSeconds(.01f);
       
    }
    public void WhenHintModeOff()
    {
        

        if (!correctPos)
        {
            rectTransform.position = new Vector3(rectTransform.position.x, lastPos, rectTransform.position.z);

            button.interactable = true;

        }

    }
}
