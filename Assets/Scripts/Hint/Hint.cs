using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

    public class Hint : MonoBehaviour
    {
        [SerializeField] List<HintScene> SceenList;
        [SerializeField] GameObject HintObject;
        [SerializeField] GameObject CharacterObject;
        [SerializeField] Image ProgressImage;
        [SerializeField] TextMeshProUGUI HintInfo;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Button HintButton;
        [SerializeField] Sprite[] ButtonSprite = new Sprite[2];
        [SerializeField] float totahints;
        float hintCounter = 0;
        public UnityEvent OnHintComplete;
        public UnityEvent OnHintModeOn;
        public UnityEvent OnHintModeOff;

        public bool HintMoed { set; get; }
        HintInfo currentHintInfo;
        MInventory inventory;
        HintScene hintScene;
        private void Awake()
        {
            inventory = FindObjectOfType<MInventory>();
            OnHintComplete.AddListener(() => SolveCurrentHint());
            OnHintComplete.AddListener(() => ShowNextHint());


        }
        // Start is called before the first frame update

        //bool IfAllSolved()
        //{

        //    foreach (HintInfo hint in LevelHints)
        //    {
        //        if (hint.IfSolve == false)
        //            return false;
        //    }
        //    return true;
        //}


        //public void ShowHint()
        //{
        //    if (IfAllSolved()) return;

        //    HintObject.SetActive(true);
        //    HintButton.image.sprite = ButtonSprite[2];

        //    foreach (HintInfo hint in LevelHints)
        //    {
        //        if (!hint.HintScene.activeInHierarchy) continue;

        //        if (hint.IfSolve) continue;

        //        Rside(hint.RSide);

        //        HintInfo.text = hint.HintNote;
        //        hint.HintCircule.SetActive(true);
        //        spriteRenderer.sprite = hint.Sprite;
        //        HintObject.SetActive(true);
        //        break;
        //    }


        //}

        public void ShowHint(int hintnumber)
        {
            if (HintMoed)
            {
                HintInfo hint = hintScene.LevelHints[hintnumber];
                currentHintInfo = hint;
                Rside(hint.RSide);
                HintInfo.text = hint.HintNote;
                hint.HintCircule.SetActive(true);
                spriteRenderer.sprite = hint.Sprite;
                HintButton.image.sprite = ButtonSprite[1];
                //print(GetProgressAmount(hintnumber));
                ProgressImage.fillAmount = GetProgressAmount();
                HintObject.SetActive(true);
            }
            else
            {
                HideHintObject();
            }
        }
        float GetProgressAmount()
        {

            return hintCounter++ / totahints;
        }
        void HideHintCircul()
        {
            if (currentHintInfo == null) return;

            currentHintInfo.HintCircule.SetActive(false);
        }

        public void HideHintObject()
        {

            HintObject.SetActive(false);
            HintButton.image.sprite = ButtonSprite[0];

            if(HintMoed)
            currentHintInfo.HintCircule.SetActive(false);
        }

        public void SolveCurrentHint()
        {
            currentHintInfo.IfSolve = true;
        }
        public void ChangeHintStateToFalse()
        {

            HintObject.SetActive(false);
            HintButton.image.sprite = ButtonSprite[0];
            hintCounter = 0;
            HintMoed = false;
            OnHintModeOff.Invoke();
            currentHintInfo.HintCircule.SetActive(false);
            hintScene = null;

        }

        private void ChangeHintStateToTrue()
        {
            HintMoed = true;
            ResetHintSystem();

            ShowNextHint();

            OnHintModeOn.Invoke();
        }

        public void HelpButtonToggelHintAndGame()
        {
            if (HintObject.activeInHierarchy)
            {
                ChangeHintStateToFalse();
            }
            else
            {
                ChangeHintStateToTrue();
            }
        }

        public void ShowNextHint()
        {
            HideHintCircul();
            GetActiveHintSceen();
            int hintnum = GetNextHintNumber();
            if (hintnum == -1)
            {
                //ChangeHintStateToFalse();
                HideHintObject();


            }
            else
            {
                ShowHint(hintnum);
            }
        }


        int GetNextHintNumber()
        {
            int hintnum = -1;

            foreach (HintInfo info in hintScene.LevelHints)
            {
                if (info.IfSolve) continue;

                hintnum = hintScene.LevelHints.IndexOf(info);
                break;
            }

            return hintnum;
        }


        public void GetActiveHintSceen()
        {
            foreach (HintScene scene in SceenList)
            {
                if (!scene.GameSceen.activeSelf) continue;
                hintScene = scene;
                break;
            }
        }
        void ResetHintSystem()
        {
            foreach (HintScene scene in SceenList)
            {
                foreach (HintInfo hint in scene.LevelHints)
                {
                    hint.IfSolve = false;
                }
            }

        }


        void Rside(bool RSide)
        {
            if (RSide)
            {
                CharacterObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                CharacterObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public int HintNumber() => currentHintInfo.HintNumber;

        public HintInfo Gethintinfo() { return currentHintInfo; }

    }

