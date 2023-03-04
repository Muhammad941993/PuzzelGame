using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NnMoveableObject : MonoBehaviour
{

     Hint hint;
    // Start is called before the first frame update
    void Start()
    {
        hint = FindObjectOfType<Hint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep()
    {
        if (hint.Gethintinfo() == null) return;

        hint.OnHintComplete.Invoke();
    }
      
}
