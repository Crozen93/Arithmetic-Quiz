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

    public TMP_Text button1Tex;
    public TMP_Text button2Tex;
    public TMP_Text button3Tex;
    public TMP_Text button4Tex;

    public TMP_Text taskTex;

    [Header("Buttons")]
    public Button qwestion1Button;
    public Button qwestion2Button;
    public Button qwestion3Button;
    public Button qwestion4Button;

    private void Awake()
    {
        instance = this;
    }
}
