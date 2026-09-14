using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LetterController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text letterField;

    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private Color missColor;
    [SerializeField]
    private Color hitColor;
    [SerializeField]
    private String defaultLetter = "_";


    private void Start() {
        //Reset();
    }

    public void SetLetter(char letter){
        letterField.text = "" + letter;
    }

    public void SetHit(){
        this.gameObject.GetComponent<Image>().color = hitColor;
    }

    public void SetMiss(){
        this.gameObject.GetComponent<Image>().color = missColor;
    }

    public void Reset(){
        // set defaults again
        letterField.text = defaultLetter;
        this.gameObject.GetComponent<Image>().color = defaultColor;
    }

    public string GetLetter(){
        if (String.Equals(letterField.text, defaultLetter)){
            return "";
        }
        return letterField.text;
    }
}
