using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Walls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Persona"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player_Inside";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Persona"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player_Outside";
        }
    }
}
