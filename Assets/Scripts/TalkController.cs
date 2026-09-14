using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkController : MonoBehaviour
{
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EscribirLento("Estas yendo de camino a casa tras un duro día de trabajo. Llegando a casa " +
            "encuentras una ambulancia en la puerta de tu edificio. \n" +
            "- Tu mujer ha tenido un accidente domestico, entre a la ambulancia y os llevaremos al hospital - Dijo el Doctor. \n" +
            "Todo parece muy extraño y te niegas a subir a la ambulancia.\n" +
            "OUCH! \n" +
            "El Doctor te ha golpeado en la cabeza fuertemente y te desmayas en el acto." ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EscribirLento(string _talk)
    {
        foreach (char caracter in _talk)
        {
            texto.text += caracter;
            yield return new WaitForSeconds(.01f);
        }
    }
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}
