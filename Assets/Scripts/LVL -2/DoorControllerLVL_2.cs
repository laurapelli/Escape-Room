using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerLVL_2 : MonoBehaviour
{
    public GameObject[] doors_Closed;
    public GameObject[] doors_Open;

    public GameObject[] doorsCollider_Outside;
    public GameObject[] doorsCollider_Inside;
    public GameObject[] doorsCollider_Interactuable;

    private bool door_Cell_Closed, door_Up_Closed;

    void Start()
    {
        door_Cell_Closed = true;
        door_Up_Closed = true;

        CloseDoor(1);
        CloseDoor(2);
    }

    
    public void OpenDoor(int i)
    {
        if (i == 1)
        {
            doors_Closed[i - 1].SetActive(false);
            doors_Open[i - 1].SetActive(true);
            doorsCollider_Outside[i - 1].SetActive(false);
            doorsCollider_Inside[i - 1].SetActive(false);
        }
        else if(i == 2)
        {
            doors_Closed[i - 1].SetActive(false);
            doors_Open[i - 1].SetActive(true);
            doorsCollider_Interactuable[i - 2].SetActive(false);
        }

        switch (i)
        {
            case 1:
                door_Cell_Closed = false;
                break;

            case 2:
                door_Up_Closed = false;
                break;
        }
    }


    public void CloseDoor(int i)
    {
        if (i == 1)
        {
            doors_Closed[i - 1].SetActive(true);
            doors_Open[i - 1].SetActive(false);
            doorsCollider_Outside[i - 1].SetActive(true);
            doorsCollider_Inside[i - 1].SetActive(true);
        }
        else if(i == 2)
        {
            doors_Closed[i - 1].SetActive(true);
            doors_Open[i - 1].SetActive(false);
            doorsCollider_Interactuable[i - 2].SetActive(true);
        }
        switch (i)
        {
            case 1:
                door_Cell_Closed = true;
                break;

            case 2:
                door_Up_Closed = true;
                break;
        }
    }

    public bool TheDoorIsClosed(int i)
    {
        switch (i)
        {
            case 1:
                return door_Cell_Closed;
            case 2:
                return door_Up_Closed;
            default: return true;
        }
    }
}
