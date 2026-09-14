using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordleController : MonoBehaviour
{
    private int currentWordContainerIndex = 0;
    public SceneChanger sceneChanger;

    [SerializeField]
    private string[] solutions = {"LAURA", "CHRIS", "IRENE"};
    private string solution;
    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectSolution();

        /*SetLetter('A');SetLetter('B');SetLetter('C');SetLetter('D');SetLetter('E');
        SetLetter('A');SetLetter('C');SetLetter('B');SetLetter('T');SetLetter('Z');
        SetLetter('Z');*/
    }

    public void SetLetter(char letter){
        if(transform.childCount == currentWordContainerIndex)
        {
            Invoke("End", 2);
            sceneChanger.LoadScene(4);
            return;
        }

        WordContainerController wordContainer = transform.GetChild(currentWordContainerIndex).GetComponent<WordContainerController>();
        int spaceLeftInThatWord = wordContainer.SetLetter(letter);
        
        if (spaceLeftInThatWord == 0){
            if (wordContainer.CompareWord(solution)){
                Invoke("End", 2);
                completed = true;
            }
            currentWordContainerIndex++;
        }
    }

    void End(){
        //Debug.Log("End");
        this.gameObject.SetActive(false);
    }

    private void SelectSolution(){
        solution = solutions[Random.Range(0, solutions.Length)];
    }
}
