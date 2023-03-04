using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneNumber : MonoBehaviour
{

    [SerializeField] int Number;
    [SerializeField] TextMeshProUGUI Text;
    PhoneController phoneController;
    private void Awake()
    {
        phoneController = FindObjectOfType<PhoneController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetNumberOnScreen()
    {
        int x = 0;

        foreach (char i in Text.text)
        {
            x++;
        }

        if (x < 5)
        {
            Text.text += Number.ToString();
        }

    }
}
