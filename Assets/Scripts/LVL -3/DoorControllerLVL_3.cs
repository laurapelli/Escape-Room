using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerLVL_3 : MonoBehaviour
{
    public GameObject[] doors_Closed; 
    public GameObject[] doors_Open;

    public GameObject[] doorsCollider_Outside;
    public GameObject[] doorsCollider_Inside;
    public GameObject[] doorsCollider_Ïnteractuable;

    private bool door_1_Closed, door_2_Closed, door_3_Closed, door_4_Closed, door_5_Closed, door_6_Closed, door_7_Closed;

    // Start is called before the first frame update
    void Start()
    {
        door_1_Closed = true;
        door_2_Closed = true; 
        door_3_Closed = true;
        door_4_Closed = true;
        door_5_Closed = true;
        door_6_Closed = true;
        door_7_Closed = true;

        CloseDoor(1);
        CloseDoor(3);
        CloseDoor(4);
        CloseDoor(5);
        CloseDoor(6);
        CloseDoor(7);
    }


    public void OpenDoor(int i)
    {
        //Debug.Log("Ha petao " +i);

        //Puertas de las celdas de izq a dch
        if (0 < i && i <= 3)
        {
            doors_Closed[i - 1].SetActive(false);
            doors_Open[i - 1].SetActive(true);
            doorsCollider_Outside[i - 1].SetActive(false);
            doorsCollider_Inside[i - 1].SetActive(false);
        }
        //Puertas de seguridad de izq a dch
        else if (4 <= i && i <= 5)
        {
            doors_Open[i - 1].SetActive(true);
            doorsCollider_Ïnteractuable[i - 4].SetActive(false);
        }
        //Puerta de la taquilla y de subir piso
        else if (6 <= i && i <= 7)
        {
            //Puerta de la taquilla 6 y Up 7
            doors_Open[i - 1].SetActive(true);
            doors_Closed[i - 1].SetActive(false);
            doorsCollider_Ïnteractuable[i - 4].SetActive(false);
        }

        switch (i)
        {
            case 1:
                door_1_Closed = false;
                break;
            case 2:
                door_2_Closed = false;
                break;
            case 3:
                door_3_Closed = false;
                break;
            case 4:
                door_4_Closed = false;
                break;
            case 5:
                door_5_Closed = false;
                break;
            case 6:
                door_6_Closed = false;
                break;
            case 7:
                door_7_Closed = false;
                break;
        }
    }


    public void CloseDoor(int i)
    {
        //Debug.Log("Ha petaooooooo " + i);
        if (0 < i && i <= 3)
        {
            //Puertas de las celdas 1 2 3
            doors_Open[i - 1].SetActive(false);
            doors_Closed[i - 1].SetActive(true);
            doorsCollider_Outside[i - 1].SetActive(true);
            doorsCollider_Inside[i - 1].SetActive(true);
        }
        else if(4<=i && i <=5)
        {
            //Puertas de seguridad 4 5
            //Debug.Log("Se cierra " + i);
            doors_Open[i - 1].SetActive(false);
            doorsCollider_Ïnteractuable[i - 4].SetActive(true);
        }
        else if(6<=i && i <= 7)
        {
            //Puerta de la taquilla 6 y Up 7
            doors_Open[i - 1].SetActive(false);
            doors_Closed[i - 1].SetActive(true);
            doorsCollider_Ïnteractuable[i - 4].SetActive(true);
        }

        switch (i)
        {
            case 1:
                door_1_Closed = true;
                break;
            case 2:
                door_2_Closed = true;
                break;
            case 3:
                door_3_Closed = true;
                break;
            case 4:
                door_4_Closed = true;
                break;
            case 5:
                door_5_Closed = true;
                break;
            case 6:
                door_6_Closed = true;
                break;
            case 7:
                door_7_Closed = true;
                break;
        }
    }

    public bool TheDoorIsClosed(int i)
    {
        switch (i)
        {
            case 1:
                return door_1_Closed;
            case 2:
                return door_2_Closed;
            case 3:
                return door_3_Closed;
            case 4:
                return door_4_Closed;
            case 5:
                return door_5_Closed;
            case 6:
                return door_6_Closed;
            case 7:
                return door_7_Closed;
            default: return true;
        }
    }

    public void ShowDoorsState()
    {
        for(int i=0; i<doors_Closed.Length; i++)
        {
            Debug.Log("Puerta " + (i+1) + " cerrada=" + TheDoorIsClosed(i + 1));
        }
    }
}
