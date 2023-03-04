using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
  //  [SerializeField] GameObject LockgameObject;
    [SerializeField] int Number = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Rotate90Degree()
    {
        Number++;

        if (Number > 3)
            Number = 0;

        
           this.transform.Rotate(Vector3.forward, 90, Space.Self);
    }

    public int GetMyKey() => Number;
}
