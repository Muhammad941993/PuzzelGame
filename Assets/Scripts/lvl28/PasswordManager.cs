using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    [SerializeField] List<PassClick> Pills;
    [SerializeField] PlayAnimation _animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckIfLevelSolved()
    {
        int counter = 0;
        foreach(PassClick pil in Pills)
        {

            if (pil.IfSolved())
            {
                counter++;
            }
        }

        if(counter == 4)
        {
            _animation.StartAnimation();
            _animation.FireOnEndEvent();
            foreach (PassClick pil in Pills)
            {
                pil.enabled = false;
            }
        }
    }

    //public void EnableNextPill()
    //{
    //    foreach (PassClick pil in Pills)
    //    {
    //        if (!pil.IfSolved())
    //        {
    //            pil.EnablePill();
    //            break;
    //        }


    //    }
    //}

    public void CheckIfPlayerPassPill(int pillnum)
    {
        if (pillnum == 1) return;

        foreach (PassClick pil in Pills)
        {
            if (pil.GetBillNumber() == 1) continue;

            if(pillnum == 2 )
            {
                if (!Pills[0].IfSolved())
                    ResetAllPills();
            }
            else if(pillnum == 3)
            {
                if (!Pills[1].IfSolved() || !Pills[0].IfSolved())
                {
                    ResetAllPills();
                }
            }else if(pillnum == 4)
            {
                if (!Pills[1].IfSolved() || !Pills[0].IfSolved() || !Pills[2].IfSolved())
                {
                    ResetAllPills();
                }
            }
           
        }


    }
    public void ResetThreePills()
    {
        foreach (PassClick pil in Pills)
        {
            if (pil.GetBillNumber() == 1) continue;

            pil.ResetPill();
        }
    }
    public void ResetAllPills()
    {
        foreach (PassClick pil in Pills)
        {
            pil.ResetPill();
        }
    }
}
