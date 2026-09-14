using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour
{

    public static Traveller instance;

    private string playerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetPlayerName(string _namePlayer)
    {
        playerName = _namePlayer;
    }

    public string PlayerName()
    {
        return playerName;
    }
}
