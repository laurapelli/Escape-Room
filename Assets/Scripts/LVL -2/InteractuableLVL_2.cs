using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractuableLVL_2 : MonoBehaviour
{
    private PlayerController player;
    public ZombieSpecialController zombieSpecial;

    public DoorControllerLVL_2 doorsController;
    public GameObject[] triggers_Doors;
    private int numDoorTrigger = -1;

    public GameObject[] button_Layers;
    private bool buttonSealed = true;

    public GameObject[] triggers_Objects;
    private int numObjectTrigger = -1;

    //public Text texto;
    //public GameObject CuadroTexto;
    //private bool activatedText = false;

    public SceneChanger sceneChange;
    //public GameObject InventoryBar;

    private void Start()
    {
        player = this.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        DoorsInteraction();
    }


    public void DoorsInteraction()
    {
        //Configuracion de las puertas
        if (Input.GetKeyDown(KeyCode.E) && (numDoorTrigger != -1))
        {
            if (doorsController.TheDoorIsClosed(numDoorTrigger))
            {
                if(numDoorTrigger == 1)
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }
                else if(numDoorTrigger == 2 && zombieSpecial.GetNumDoorTrigger() == 3)
                {
                    buttonSealed = false;
                    button_Layers[0].SetActive(false);
                    button_Layers[1].SetActive(true);
                }
                else if (numDoorTrigger == 3 && zombieSpecial.GetNumDoorTrigger() == 2)
                {
                    buttonSealed = false;
                    button_Layers[0].SetActive(false);
                    button_Layers[1].SetActive(true);
                }
                else if(numDoorTrigger == 4)
                {
                    doorsController.OpenDoor(numDoorTrigger);
                }

            }
            else if (!doorsController.TheDoorIsClosed(numDoorTrigger))
            {
                doorsController.CloseDoor(numDoorTrigger);
            }
        }
    }


    //private void ShowText(string mensaje)
    //{
    //    CuadroTexto.SetActive(true);
    //    activatedText = true;
    //    texto.text = mensaje;
    //}

    //private void HideText()
    //{
    //    //wordle[4].SetActive(true);
    //    CuadroTexto.SetActive(false);
    //    activatedText = false;
    //}


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
