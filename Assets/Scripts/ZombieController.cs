using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private bool allowedToMoveInY;
    private bool allowedToMoveInX;
    private string blockingLayer;

    [Header("movement")]
    private Vector2 deltaMove;
    private Vector2 actualPosition;
    [SerializeField]
    private float movementSpeed;
    private float speedPatrol;
    private float speedChasing;
    private Animator anim;

    private Vector2 position;
    private Vector2 nextPosition;
    public float nextPosition_X;
    public float nextPosition_Y;
    private bool targetFound;
    public float distanceDetection;
    public float distanceKill;
    public GameObject player;
    private Vector2 targetVector;

    public SceneChanger sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        anim = GetComponent<Animator>();

        //Inicializo los puntos de ruta
        position = transform.position;
        nextPosition = new Vector2(nextPosition_X, nextPosition_Y);

        //Inicializo las variables para buscar al player
        targetFound = false;
        targetVector = new Vector2(0.0f, 0.0f);

        speedPatrol = movementSpeed;
        speedChasing = movementSpeed * 1.2f;

        actualPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float step = movementSpeed;
        actualPosition = transform.position;

        LookForTarget();
        

        //Si el player esta cerca va a por el, sino al punto de patrulla
        if (targetFound)
        {
            deltaMove = Vector2.MoveTowards(transform.position, player.transform.position, step * Time.deltaTime);
        }
        else
        {
            deltaMove = Vector2.MoveTowards(transform.position, nextPosition, step * Time.deltaTime);
        }
        //Debug.Log(deltaMove);
        deltaMove = deltaMove - actualPosition;
        //deltaMove.Normalize();
        //Debug.Log(deltaMove);

        //Debug.Log("x->" + transform.position.x + "     y->" + transform.position.y);
        //Debug.Log("Cambia Patrol side a " + nextPosition);
        if (transform.position.x == nextPosition.x && transform.position.y == nextPosition.y)
        {
            ChangePatrolSide();

        }


        //Activar layers dentro y fuera de las habitaciones
        if (GetComponent<SpriteRenderer>().sortingLayerName == "Player_Inside")
        {
            blockingLayer = "Blocking_Inside";
            //Debug.Log("Bloquea dentro");
        }
        else if (GetComponent<SpriteRenderer>().sortingLayerName == "Player_Outside")
        {
            blockingLayer = "Blocking_Outside";
            //Debug.Log("Bloquea fuera");
        }

        
        //allowedToMoveInY = false;
        //allowedToMoveInX = false;

        //Colisiones BoxCast(posicion actual, tamaño collider, rotacion, direccion de movimiento, distancia, capas con las que tenderemos collider)
        //Comprobamos si podemos movernos en el eje y, casteando una caja en esa posicion y si devuelve nulo nos podemos mover
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaMove.y), Mathf.Abs(deltaMove.y), LayerMask.GetMask("Human", blockingLayer));
        if (hit.collider == null)
        {
            //Movimiento al player
            if (deltaMove.y > 0  && Mathf.Abs(deltaMove.y) > Mathf.Abs(deltaMove.x))
            {
                anim.SetBool("LookUp", true);
                anim.SetBool("LookDown", false);
            }
            else if (deltaMove.y < 0  && Mathf.Abs(deltaMove.y) > Mathf.Abs(deltaMove.x))
            {
                anim.SetBool("LookDown", true);
                anim.SetBool("LookUp", false);
            }
            else
            {
                anim.SetBool("LookDown", false);
                anim.SetBool("LookUp", false);
            }

            //transform.position = new Vector3(transform.position.x, deltaMove.y + transform.position.y, 0);
            transform.Translate(0, deltaMove.y, 0);
            //allowedToMoveInY = true;
            //Debug.Log("allowedToMoveInY = " + allowedToMoveInY);
        }
        else if(hit.collider != null)
        {
            //Debug.Log("pipiobkbhsdcf");
        }

        //Lo mismo eje x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaMove.x, 0), Mathf.Abs(deltaMove.x), LayerMask.GetMask("Human", blockingLayer));
        if (hit.collider == null)
        {
            //Movimiento al player
            if (deltaMove.x > 0  && Mathf.Abs(deltaMove.x) > Mathf.Abs(deltaMove.y))
            {
                anim.SetBool("LookRight", true);
                anim.SetBool("LookLeft", false);
            }
            else if (deltaMove.x < 0  && Mathf.Abs(deltaMove.x) > Mathf.Abs(deltaMove.y))
            {
                anim.SetBool("LookRight", false);
                anim.SetBool("LookLeft", true);
            }
            else
            {
                anim.SetBool("LookRight", false);
                anim.SetBool("LookLeft", false);
            }

            //transform.position = new Vector3(deltaMove.x + transform.position.x, transform.position.y, 0);
            transform.Translate(deltaMove.x, 0, 0);
            //allowedToMoveInX = true;
            //Debug.Log("allowedToMoveInX = "+ allowedToMoveInX);
        }
        else if (hit.collider != null)
        {
            //Debug.Log("pipiobkbhsdcf");
        }

        actualPosition = transform.position;
        //if (allowedToMoveInY && allowedToMoveInX)
        //{
        //    transform.position = new Vector3(deltaMove.x, deltaMove.y, 0f);
        //}
    }



    //Cambia la direccion de la patrulla
    private void ChangePatrolSide()
    {
        Vector2 aux = position;
        position = nextPosition;
        nextPosition = aux;
    }

    //Busca al player y si esta en el radio de deteccíon lo persigue
    private void LookForTarget()
    {
        //Debug.Log("buscando target");
        targetVector = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        if (targetVector.magnitude < distanceKill)
        {
            sceneChange.LoadScene(3);
        }
        else if (targetVector.magnitude < distanceDetection)
        {
            targetFound = true;
            movementSpeed = speedChasing;
        }
        else
        {
            targetFound = false;
            movementSpeed = speedPatrol;
        }
        //Debug.Log("Zombie speed-> " + movementSpeed);
    }

    //Busca la posicion de patrulla mas cercana
    private void LookForPatrolSide()
    {
        Vector2 toPatrolPoint1 = new Vector2(nextPosition.x - this.transform.position.x, nextPosition.y - this.transform.position.y);
        Vector2 toPatrolPoint2 = new Vector2(position.x - this.transform.position.x, position.y - this.transform.position.y);

        float distanceToPoint1 = toPatrolPoint1.magnitude;
        float distanceToPoint2 = toPatrolPoint2.magnitude;

        if(distanceToPoint1 > distanceToPoint2)
        {
            ChangePatrolSide();
        }
    }

    //private void MoveZombie()
    //{
    //    float step = movementSpeed * Time.deltaTime;
    //    actualPosition = transform.position;

    //    LookForTarget();

    //    //Si el player esta cerca va a por el, sino al punto de patrulla
    //    if (targetFound)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    //    }
    //    else
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, nextPosition, step);
    //    }

    //    deltaMove = new Vector3(transform.position.x - actualPosition.x, transform.position.y - actualPosition.y);
    //    //Debug.Log("x->" + deltaMove.x + "     y->" + deltaMove.y);
    //}
}
