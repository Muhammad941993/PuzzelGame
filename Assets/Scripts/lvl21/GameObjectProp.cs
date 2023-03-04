using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectProp : MonoBehaviour
{
    [SerializeField] float Seconds =1;
    [SerializeField] bool activeOnstart = true;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if(activeOnstart)
        DisableAfterSecond(Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        DisableAfterSecond(Seconds);
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



}


