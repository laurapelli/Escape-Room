using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private string blockingLayer;

    [Header("movement")]
    private Vector3 deltaMove;
    private float movementSpeed = 0.8f;
    private Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    
    private void FixedUpdate()
    {
        //Input del movimiento y asignacion al vector deltaMove
        float x = movementSpeed * Input.GetAxisRaw("Horizontal");
        float y = movementSpeed * Input.GetAxisRaw("Vertical");
        deltaMove = new Vector3(x, y, 0);

        //Asigna que collider le va a afectar
        if (GetComponent<SpriteRenderer>().sortingLayerName == "Player_Inside")
        {
            blockingLayer = "Blocking_Inside";
        }
        else if (GetComponent<SpriteRenderer>().sortingLayerName == "Player_Outside")
        {
            blockingLayer = "Blocking_Outside";
        }

        //Colisiones BoxCast(posicion actual, tamaño collider, rotacion, direccion de movimiento, distancia, capas con las que tenderemos collider)

        //Comprobamos si podemos movernos en el eje y, casteando una caja en esa posicion y si devuelve nulo nos podemos mover
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaMove.y), Mathf.Abs(deltaMove.y*Time.deltaTime), LayerMask.GetMask("Human", blockingLayer));
        if(hit.collider == null)
        {
            //Movimiento al player
            if (deltaMove.y > 0)
            {
                anim.SetBool("LookUp", true);
                anim.SetBool("LookDown", false);
            }
            else if (deltaMove.y < 0)
            {
                anim.SetBool("LookDown", true);
                anim.SetBool("LookUp", false);
            }
            else
            {
                anim.SetBool("LookDown", false);
                anim.SetBool("LookUp", false);
            }

            transform.Translate(0, deltaMove.y * Time.deltaTime, 0);
        }

        //Lo mismo eje x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaMove.x, 0), Mathf.Abs(deltaMove.x * Time.deltaTime), LayerMask.GetMask("Human", blockingLayer));
        if (hit.collider == null)
        {
            //Movimiento al player
            if (deltaMove.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                anim.SetBool("LookLeft",true);
            }
            else if (deltaMove.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                anim.SetBool("LookLeft", true);
            }
            else
            {
                anim.SetBool("LookLeft", false);
            }

            transform.Translate(deltaMove.x * Time.deltaTime, 0, 0);
        }
    }

    public void SetMovementSpeed(float s)
    {
        movementSpeed = s;
    }
}
