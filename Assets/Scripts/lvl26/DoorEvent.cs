using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{

    [SerializeField] CheckPassWord passWord;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        passWord.OnEnterCorrectPassword.AddListener(() => PlayAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PlayAnimation()
    {
        animator.SetTrigger("play");
    }
}
