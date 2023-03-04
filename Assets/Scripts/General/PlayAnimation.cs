using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAnimation : MonoBehaviour 
{
    [SerializeField] Animator animator;
    [SerializeField] float delaytime = 1;
    public UnityEvent OnLevelEnd;

    public void StartAnimation()
    {
        Invoke("Play", delaytime);
    }

    void Play()
    {
        animator.SetTrigger("play");
    }



    public void FireOnEndEvent()
    {
        Invoke("Onend", delaytime);
    }

    void Onend()
    {
        OnLevelEnd.Invoke();
    }

  
}
