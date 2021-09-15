using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance { get; private set; }

    [Header("Text")]
    public TMP_Text timerTex;
    public TMP_Text raitingTex;
    public TMP_Text winTex;
    public TMP_Text loseTex;
    public TMP_Text taskTex;
    public TMP_Text[] buttonTex;

    [Header("Buttons")]
    public Button[] qwestionButton;

    private void Awake()
    {
        instance = this;
    }

    public void ButtonHundler(Button pressedbutton)
    {
        //Diactiveted all buttons
        for (int i = 0; i < qwestionButton.Length; i++)
        {
            qwestionButton[i].enabled = false;
        }

        //check true button
        if (pressedbutton.transform.GetChild(0).GetComponent<TMP_Text>().text == GeneralController.instance.trueNum.ToString())
        {
            GeneralController.instance.raitingScore += 10;
            winTex.gameObject.SetActive(true);
            Timer.instance.roundTime = 0;
        }
        else
        {
            GeneralController.instance.raitingScore -= 5;
            loseTex.gameObject.SetActive(true);
            Timer.instance.roundTime = 0;
        }
    }

    public void ButtonCheckColor()
    {
        for (int i = 0; i < qwestionButton.Length; i++)
        {
            if ((qwestionButton[i].transform.GetChild(0).GetComponent<TMP_Text>().text == GeneralController.instance.trueNum.ToString()))
            {
                var colors = qwestionButton[i].colors;
                colors.normalColor = Color.green;
                colors.selectedColor = Color.green;
                colors.highlightedColor = Color.green;                
                qwestionButton[i].colors = colors;
            }
            else
            {
                var colors = qwestionButton[i].colors;
                colors.normalColor = Color.red;
                colors.selectedColor = Color.red;
                colors.highlightedColor = Color.red;
                qwestionButton[i].colors = colors;
            }
        }
    }

    public void ButtonStandartColor()
    {
        for (int i = 0; i < qwestionButton.Length; i++)
        {
            var colors = qwestionButton[i].colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            colors.highlightedColor = Color.white;
            qwestionButton[i].colors = colors;

            qwestionButton[i].enabled = true;
        }
        winTex.gameObject.SetActive(false);
        loseTex.gameObject.SetActive(false);
        
    }
}
