using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance { get; private set; }

    public float roundTime;
    public float roundTimeOut;
    private int roundConvertTime;

    private void Awake()
    {
        instance = this;
    }

    // Timer - round
    public void TimerRoundStart()
    {        
        roundTime -= Time.deltaTime;
        roundConvertTime = (int)roundTime;
        UiController.instance.timerTex.text = roundConvertTime.ToString();
    }

    // Timer - timeout
    public void TimerOutRoundStart()
    {
        roundTimeOut -= Time.deltaTime;
    }
}
