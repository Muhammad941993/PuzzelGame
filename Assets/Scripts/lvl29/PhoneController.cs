using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PhoneController : MonoBehaviour
{
    [SerializeField] int PhoneNumber;
    [SerializeField] TextMeshProUGUI PhoneText;
    public UnityEvent OnCall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckPhoneNumber()
    {
        int N = 0;
        int.TryParse(PhoneText.text, out N);

        if(N == PhoneNumber)
        {
          
            PhoneText.text = "Calling Guard";
            StartCalling();

        }
        else
        {
            PhoneText.text = "Error";
        }
                
    }

    public void ResetCall()
    {
        PhoneText.text = "";
    }


    void StartCalling()
    {
        OnCall.Invoke();
    }
}
