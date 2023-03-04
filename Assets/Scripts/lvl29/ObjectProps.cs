using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProps : MonoBehaviour
{
    [SerializeField] float Time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableAfterSecond(float second)
    {
        Invoke("DisableGameObject", second);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }


    public void EnableAfterSecond(float second)
    {
        Invoke("EnableGameObject", second);
    }

    void EnableGameObject()
    {
        gameObject.SetActive(true);
    }

    public void ToggelShow()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    public void DestroyGameObject(float time)
    {
        Destroy(gameObject,time);
    }
}
