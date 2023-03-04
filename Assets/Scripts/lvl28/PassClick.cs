using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassClick : MonoBehaviour
{
    [SerializeField] bool MainPill;
    [SerializeField] int PillNumber;
    [SerializeField] bool Solved;
    [SerializeField] int SolveNumber;
    [SerializeField] int ClickedNumber = 0;
    [SerializeField] GameObject hammer;
  //  bool enable = true;
    PasswordManager manager;
    bool startHit = false;
    AudioSource audioSource;

    float TimeGap = 1f;
    float counter = 0;
    private void Awake()
    {
        manager = FindObjectOfType<PasswordManager>();
        audioSource = GetComponent<AudioSource>();
       // DisablePill();
    }
    public bool IfSolved() => Solved;

    public int GetBillNumber() => PillNumber;

    private void FixedUpdate()
    {
        counter += Time.deltaTime;
    }
    private void OnMouseDown()
    {
       
          if (!startHit) return;

        if (counter < TimeGap) return;

            audioSource.Play();
        hammer.SetActive(true);
        ClickedNumber++;

        manager.CheckIfPlayerPassPill(PillNumber);

        if (MainPill)
        {
            if(ClickedNumber == 1)
            {
                manager.ResetThreePills();
            }

            if (ClickedNumber >= SolveNumber)
            {
                Solved = true;
              
            }
            else
            {
                Solved = false;
            }
        }
        else
        {
            if (ClickedNumber == SolveNumber)
            {
                Solved = true;
            }
            else
            {
                Solved = false;
            }
        }

        manager.CheckIfLevelSolved();
        counter = 0;
    }


    public void EnableHammerHit()
    {
        startHit = true;
    }
    public void DisableHammerHit()
    {
        startHit = false;
    }
   
    public void ResetPill()
    {
        ClickedNumber = 0;
        Solved = false;
    }
}
