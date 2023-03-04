using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{

    [SerializeField] int Password = 0;
    [SerializeField] List<LockRotation> locks = new();
    [SerializeField] GameObject MainDoor;

    [SerializeField]string pass = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckPassword()
    {
        pass = "";
        foreach (var lockRotation in locks)
        {
           pass += lockRotation.GetMyKey();
        }

        if(pass == Password.ToString())
        {
            MainDoor.SetActive(false);

            gameObject.SetActive(false);
        }
    }
}
