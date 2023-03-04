using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    [SerializeField] PlayAnimation PlayAnimation;
    [SerializeField] ItemMovement itemMovement1;
    [SerializeField] ItemMovement itemMovement2;

    public UnityEvent OnFinish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IfCorrectPlayAnimation()
    {
        if (itemMovement1.CorrectPosition() && itemMovement2.CorrectPosition())
        {
            PlayAnimation.StartAnimation();

            OnFinish.Invoke();
        }
    }
}
