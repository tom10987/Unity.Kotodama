﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.Events;

public class DialButton_Ver2 : MonoBehaviour
{
    [SerializeField]
    Text Dial;

    [SerializeField]
    string TrueNumber = null;

    [SerializeField]
    public bool clear = false;

    [SerializeField]
    int StringLimit = 10;

    [SerializeField]
    int HyphenPoint = 3;

    void Start()
    {
        Dial.text = null;
    }
	
    public void Number(int i)
    {
        if(Dial.text.Length < StringLimit)
            Dial.text += i.ToString();
        if(Dial.text.Length == HyphenPoint)
            Dial.text += "-";
    }

    public void BackSpace()
    {
        Dial.text = null;
    }

    public void Enter()
    {
        if(Dial.text == TrueNumber)
        {
            clear = true;
        }
    }
}