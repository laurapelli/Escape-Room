using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuableLVL_3 : MonoBehaviour
{
    private PlayerController player;

    public DoorControllerLVL_3 doorsController;
    public GameObject[] triggers_Doors;
    private int numDoorTrigger = -1;
    private bool llaveGris = false;
    private bool llaveAmarilla = false;
    private bool llaveRoja = false;
    public GameObject llaveGrisObject;
    public GameObject llaveAmarillaObject;
    public GameObject llaveRojaObject;

    public GameObject[] triggers_Objects;
    private int numObjectTrigger = -1;

    public Text texto;
    public GameObject CuadroTexto;
    private bool activatedText = false;
    public GameObject[] wordle;
    private bool activatedWordle = false;

    public SceneChanger sceneChange;
    public GameObject InventoryBar;


    private void Start()
    {
        player = this.gameObject.GetComponent<PlayerController>();
    }


    private void Update()
    {
        DoorsInteraction();
        ObjectsInteractions();
    }


    public void DoorsInteraction()
    {
        //Configuracion de las puertas
        if (Input.GetKeyDown(KeyCode.E) && (numDoorTrigger != -1) && (numDoorTrigger != 6) && activatedText == false)
        {
            if (doorsController.TheDoorIsClosed(numDoorTrigger))
            {
                if ((1 <= numDoorTrigger && numDoorTrigger <= 3) && (llaveGris == true))
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }
                else if ((numDoorTrigger == 4) && (llaveAmarilla == true))
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }
                else if ((numDoorTrigger == 5) && (llaveRoja == true))
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }
                else if (numDoorTrigger == 7)
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }
                else if ((1 <= numDoorTrigger && numDoorTrigger <= 3) && (llaveGris == false))
                {
                    ShowText("No tengo la llave para esta puerta");
                    player.SetMovementSpeed(0f);
                }
                else if ((numDoorTrigger == 4) && (llaveAmarilla == false))
                {
                    ShowText("No tengo la llave para esta puerta");
                    player.SetMovementSpeed(0f);
                }
                else if ((numDoorTrigger == 5) && (llaveRoja == false))
                {
                    ShowText("No tengo la llave para esta puerta");
                    player.SetMovementSpeed(0f);
                }
            }
            else if (!doorsController.TheDoorIsClosed(numDoorTrigger))
            {
                doorsController.CloseDoor(numDoorTrigger);
            }

            //doorsController.ShowDoorsState();
        }
        else if (Input.GetKeyDown(KeyCode.E) && (numDoorTrigger != -1) && numDoorTrigger != 6 && activatedText == true)
        {
            HideText();
            player.SetMovementSpeed(0.8f);
        }
    }



    public void ObjectsInteractions()
    {
        if (Input.GetKeyDown(KeyCode.E) && (numObjectTrigger != -1) && activatedText == false && activatedWordle == false)
        {
            player.SetMovementSpeed(0f);

            switch (numObjectTrigger)
            {
                case 1:
                    if (!llaveGris)
                    {
                        InventoryBar.gameObject.SetActive(true);
                        ShowText("Has recogido una llave");
                        llaveGrisObject.SetActive(true);
                        llaveGris = true;
                        //Debug.Log("Has recogido unas esposas");
                    }
                    else if (llaveGris)
                    {
                        ShowText("Parece que no hay nada más");
                    }
                    break;
                case 2:
                    ShowText("Parece que nos vigilaban con cámaras");
                    //Debug.Log("Parece que nos vigilaban con cámaras");
                    break;
                case 3:
                    if (!wordle[0].GetComponent<WordleController>().completed)
                    {
                        ShowText("Dice: ''Adivina la palabra para obtener la combinacion de la taquilla''");
                        //Debug.Log("Dice: ''Adivina la palabra para obtener la combinacion de la taquilla''");
                    }
                    else if (wordle[0].GetComponent<WordleController>().completed)
                    {
                        ShowText("Dice: ''La combinación de la taquilla es llave''");
                        player.SetMovementSpeed(0f);
                    }
                    break;
                case 4:
                    ShowText("Parece que no funciona el ascensor");
                    //Debug.Log("Parece que no funciona el ascensor");
                    break;
                case 5:
                    ShowText("Vaya, los botones de dentro tampoco hacen nada...");
                    //Debug.Log("Vaya, los botones de dentro tampoco hacen nada...");
                    break;
                case 6:
                    if (!llaveAmarilla)
                    {
                        ShowText("Has recogido una llave");
                        llaveAmarillaObject.SetActive(true);
                        llaveAmarilla = true;
                        //Debug.Log("Vaya, los botones de dentro tampoco hacen nada...");
                    }
                    else if (llaveAmarilla)
                    {
                        ShowText("Que asco no quiero buscar más en la sangre");
                    }
                    break;
            }
            

        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && numObjectTrigger != 3 && numDoorTrigger != 6 && numObjectTrigger != -1)
        {
            HideText();
            player.SetMovementSpeed(0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && activatedWordle == false && numObjectTrigger == 3 && wordle[0].GetComponent<WordleController>().completed)
        {
            HideText();
            player.SetMovementSpeed(0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && activatedWordle == false && numObjectTrigger == 3 && !wordle[0].GetComponent<WordleController>().completed)
        {
            HideText();
            activatedWordle = true;
            //wordle[0] = Instantiate(wordlePrefab_Ordenador);
            wordle[0].SetActive(true);
            player.SetMovementSpeed(0f);
            //Debug.Log("activated text= " + activatedText + "        activatedWordle=" + activatedWordle);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == false && activatedWordle == true && wordle[0].GetComponent<WordleController>().completed && numObjectTrigger == 3)
        {
            ShowText("Dice: ''La combinación de la taquilla es llave''");
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && activatedWordle == true && numObjectTrigger == 3)
        {
            activatedWordle = false;
            HideText();
            player.SetMovementSpeed(0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == false && activatedWordle == false && numDoorTrigger == 6)
        {
            player.SetMovementSpeed(0f);

            if (!wordle[0].GetComponent<WordleController>().completed)
            {
                ShowText("Requiere una cobinación para abrirla, seguro que encuentro alguna pista");
            }
            else if (wordle[0].GetComponent<WordleController>().completed && !wordle[1].GetComponent<WordleController>().completed)
            {
                ShowText("Voy a probar con la combinación del ordenador");
            }
            else if (wordle[0].GetComponent<WordleController>().completed && wordle[1].GetComponent<WordleController>().completed)
            {
                ShowText("No hay nada más en la taquilla");
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && activatedWordle == false && wordle[0].GetComponent<WordleController>().completed && !wordle[1].GetComponent<WordleController>().completed && numDoorTrigger == 6)
        {
            activatedWordle = true;
            HideText();
            wordle[1].SetActive(true);
            player.SetMovementSpeed(0f);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == false && activatedWordle == true && wordle[1].GetComponent<WordleController>().completed && numDoorTrigger == 6)
        {
            activatedWordle = false;
            ShowText("Has recogido una llave roja");
            llaveRojaObject.SetActive(true);
            llaveRoja = true;
            doorsController.OpenDoor(6);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activatedText == true && activatedWordle == false && numDoorTrigger == 6)
        {
            HideText();
            player.SetMovementSpeed(0.8f);
        }
    }

    private void ShowText(string mensaje)
    {
        CuadroTexto.SetActive(true);
        activatedText = true;
        texto.text = mensaje;
    }

    private void HideText()
    {
        //wordle[4].SetActive(true);
        CuadroTexto.SetActive(false);
        activatedText = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Controla que puerta se abre con su trigger
        for (int i = 0; i < triggers_Doors.Length; i++)
        {
            if (triggers_Doors[i] == collision.gameObject)
            {
                numDoorTrigger = i + 1;
            }
        }
        if (numDoorTrigger == 8)
        {
            sceneChange.LoadScene(4);
        }

        //Controla que objeto se activa con su trigger
        for (int i = 0; i < triggers_Objects.Length; i++)
        {
            if (triggers_Objects[i] == collision.gameObject)
            {
                numObjectTrigger = i + 1;
            }
        }

        //Debug.Log("Trigger activado -> " + numObjectTrigger);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Controla que puerta se abre con su trigger
        for (int i = 0; i < triggers_Doors.Length; i++)
        {
            if (triggers_Doors[i] == collision.gameObject)
            {
                numDoorTrigger = -1;
            }
        }

        //Controla que objeto se activa con su trigger
        for (int i = 0; i < triggers_Objects.Length; i++)
        {
            if (triggers_Objects[i] == collision.gameObject)
            {
                numObjectTrigger = -1;
            }
        }

        //Debug.Log("Trigger activado -> " + numObjectTrigger);
    }
}
