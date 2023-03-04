using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CheckPassWord : MonoBehaviour 
{
    [SerializeField] int password;
    [SerializeField] GameObject Action;
    [SerializeField] TextMeshProUGUI[] text;

    public UnityEvent OnEnterCorrectPassword;

    public void CheckPassword()
    {
        if (IfCorrect())
        {
            OnEnterCorrectPassword.Invoke();
            gameObject.SetActive(false);
        }
      
    }
    

    bool IfCorrect()
    {
        if (ReadPassword() == password)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    int ReadPassword()
    {
        string x = "";
        foreach (TextMeshProUGUI i in text)
        {
            x += i.text;
        }
        return int.Parse(x);
    }



    public void SetNumbers(int textOrder)
    {
       int x = int.Parse(text[textOrder].text);
        if(x >= 9)
        {
            text[textOrder].text = "0";
        }
        else
        {
            text[textOrder].text = (x + 1).ToString();
        }
       
    }

   
}
