using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralController : MonoBehaviour
{
    public static GeneralController instance { get; private set; }
    public int raitingScore;        // raiting score
    public float trueNum;           // true number 


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        //button hundlers
        UiController.instance.qwestionButton[0].onClick.AddListener(() => UiController.instance.ButtonHundler(UiController.instance.qwestionButton[0]));
        UiController.instance.qwestionButton[1].onClick.AddListener(() => UiController.instance.ButtonHundler(UiController.instance.qwestionButton[1]));
        UiController.instance.qwestionButton[2].onClick.AddListener(() => UiController.instance.ButtonHundler(UiController.instance.qwestionButton[2]));
        UiController.instance.qwestionButton[3].onClick.AddListener(() => UiController.instance.ButtonHundler(UiController.instance.qwestionButton[3]));

        RandomQwestionLogick(); //start
    }


    void Update()
    {
        Timer.instance.TimerRoundStart();   //update timer
        GameStateController(20, 1);         //Game state controler (first argument - round time, second argument - time out round) 
    }

    // Game State
    void GameStateController(float timeRound, float timeOutRound)
    {
        //timer round state
        if (Timer.instance.roundTime <= 0)
        {
            Timer.instance.TimerOutRoundStart();

            UiController.instance.ButtonCheckColor();
            if (Timer.instance.roundTimeOut <= 0)
            {
                Timer.instance.roundTime    = timeRound;
                Timer.instance.roundTimeOut = timeOutRound;

                UiController.instance.ButtonStandartColor();
                RandomQwestionLogick();
            }
        }
        //ui update
        UiController.instance.raitingTex.text = raitingScore.ToString();
    }

    void RandomQwestionLogick()
    {
        //init
        float a = 0;                        // init first num
        float b1 = 0;                       // init second num
        float c = 0;                        // init result num
        float b2, b3, b4;                   // init random nums
        int mathOperator = 0;               // init math operator
        string formula = null;              // init formula string

        //random
        mathOperator = Random.Range(0, 4);   //random - operator
        a = Random.Range(1, 50);             //random - num a
        b1 = Random.Range(1, 10); ;          //random - num b1

        trueNum = b1;

        //check repeat nums: b1.b2.b3.b4
        do
        {
            b2 = b1 + Random.Range(-3, 2);      // random numbers in increments of 2, -3
            b3 = b1 + Random.Range(-3, 2);      // random numbers in increments of 2, -3
            b4 = b1 + Random.Range(-3, 2);      // random numbers in increments of 2, -3
        }
        while (b1 == b2 || b1 == b3 || b1 == b4 || b2 == b3 || b2 == b4 || b3 == b4);

        //calculation
        //plus
        if (mathOperator == 0) 
        {
            c = a + b1;
            formula = a.ToString() + " + " + "?" + " = " + c.ToString();
        }
        //minus
        if (mathOperator == 1) 
        {
            c = a - b1;
            formula = a.ToString() + " - " + "?" + " = " + c.ToString();
        }
        //mnoj
        if (mathOperator == 2) 
        {
            c = a * b1;
            formula = a.ToString() + " * " + "?" + " = " + c.ToString();
        }
        //del
        if (mathOperator == 3) 
        {           
            c = a / b1;
            formula = a.ToString() + " / " + "?" + " = " + System.Math.Round(c, 1).ToString();
        }

        //UI
        UiController.instance.taskTex.text = formula;

        //Shufle massive 
        ShuffleMassive(UiController.instance.buttonTex);

        //fill buttons text nums: b1,b2,b3,b4
        UiController.instance.buttonTex[0].text = b1.ToString();
        UiController.instance.buttonTex[1].text = b2.ToString();
        UiController.instance.buttonTex[2].text = b3.ToString();
        UiController.instance.buttonTex[3].text = b4.ToString();

    }

    //shuffle massive - realization algorithm(Fisher-Yates Shuffle)
    void ShuffleMassive(TMP_Text[] textMassive)
    {
        System.Random rand = new System.Random();
        for (int i = UiController.instance.buttonTex.Length - 1; i > 1; i--)
        {
            int j = rand.Next(i + 1);

            var tmp = UiController.instance.buttonTex[j];
            UiController.instance.buttonTex[j] = UiController.instance.buttonTex[i];
            UiController.instance.buttonTex[i] = tmp;
        }
    }

   


   
}
