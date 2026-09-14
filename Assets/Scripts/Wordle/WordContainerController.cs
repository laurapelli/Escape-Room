using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordContainerController : MonoBehaviour
{
    private int currentLetter = 0;

    // returns the space left over
    public int SetLetter(char letter){
        transform.GetChild(currentLetter).GetComponent<LetterController>().SetLetter(letter);
        currentLetter++;
        return transform.childCount - currentLetter;
    }

    public bool CompareWord(string word){
        int mistakes = 0;

        // for all letters
        for(int i = 0; i < transform.childCount; i++){
            LetterController letterController = transform.GetChild(i).GetComponent<LetterController>();

            string currentLetter = letterController.GetLetter();
            
            // if char is correct
            if (word[i] == currentLetter[0]){
                letterController.SetHit();
            } else
            // if char is in word
            if (word.Contains(currentLetter)){
                letterController.SetMiss();
                mistakes++;
            } else {
                mistakes++;
            }
        }

        return mistakes == 0;
    }

    // unused
    public string GetWord(){
        string answer = "";

        for(int i = 0; i < transform.childCount; i++){
            string currentLetter = transform.GetChild(i).GetComponent<LetterController>().GetLetter();
            answer = answer + currentLetter;
        }

        return answer;
    }
}
