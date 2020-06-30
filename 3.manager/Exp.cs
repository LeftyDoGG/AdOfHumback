using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public int expValue = 10;
    public int startingEXP = 0;
    public int currentExp;
    public Slider ExpSlider;

    ScoreManager scoreM;



    void Awake()
    {
        currentExp = startingEXP;
        
    }

    void Update()
    {
        if (ScoreManager.score >=80)
        {
            currentExp += expValue;
            ExpSlider.value = expValue;
        }        
    }
}
