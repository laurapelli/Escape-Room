using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject panelPlayer;
    public GameObject panelInstructions;

    public GameObject startButton;
    public GameObject instructionsButton;

    public TMP_InputField playerName;

    // Start is called before the first frame update

    //Completar las instrucciones


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUpPanelPlay()
    {
        panelPlayer.SetActive(true);
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        panelInstructions.SetActive(false);
    }

    public void SetUpPanelInstructions()
    {
        panelInstructions.SetActive(true);
        panelPlayer.SetActive(false);
        startButton.SetActive(false);
        instructionsButton.SetActive(false);

    }
    public void DesactivePanel()
    {
        panelInstructions.SetActive(false);
        panelPlayer.SetActive(false);
        startButton.SetActive(true);
        instructionsButton.SetActive(true);

    }
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }


    public void CheckName()
    {
        if (string.IsNullOrEmpty(playerName.text))
        {
            return;
        }
        Traveller.instance.SetPlayerName(playerName.text);

        LoadScene(1);
    }
}
