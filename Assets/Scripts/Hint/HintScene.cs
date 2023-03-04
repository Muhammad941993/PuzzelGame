using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScene : MonoBehaviour
{
    public GameObject GameSceen;
    public List<HintInfo> LevelHints = new();
  



}



[System.Serializable]
public class HintInfo
{
    public int HintNumber;
    public string HintNote;
    public Sprite Sprite;
    public GameObject HintCircule;
    public GameObject HintScene;
    public bool RSide;
    public bool IfSolve;
}
