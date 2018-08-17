using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class C_CS_TornadoBehaviour_NM_1 : MonoBehaviour
{

    public static GameObject tornadoTop;
    public static GameObject[] tornadokap;
    private static GameObject tornadoBottom;
    private static GameObject firstTornado;
    public int DespawnTime = 10;
    private List<GameObject> tornadolist;

    // Use this for initialization
    void Start()
    {
        tornadolist = new List<GameObject>();

        if (!firstTornado)
        {
            NewTornado();
        }
        else
        {
            Destroy(firstTornado);
            NewTornado();
        }

        Invoke("DestroyAfterTime", DespawnTime);
    }

    void DestroyAfterTime()
    {
        
        Destroy(this.gameObject);

    }

    private void OnDestroy()
    {
        foreach (var go in tornadolist)
        {
            if (go)
            {
                var oldtrans = go.transform;
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!tornadokap[0])
        {
           
            if ((collision.tag == "Movables" || collision.tag == "Gegner") && (collision.attachedRigidbody))
            {
                tornadokap[0] = collision.gameObject;
                tornadokap[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                TornadoTransition(collision.gameObject, true, tornadoTop.transform);

                tornadolist.Add(collision.gameObject);
            }
        }

        else
        {
            if ((collision.tag == "Movables" || collision.tag == "Gegner") && (collision.attachedRigidbody))
            {
                TornadoTransition(collision.gameObject, true, tornadoBottom.transform);
                tornadolist.Add(collision.gameObject);
            }
        }
        
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject == tornadokap[0])
        {
            TornadoTransition(collision.gameObject, true, tornadoTop.transform);

        }
        if (collision.gameObject != tornadokap[0])
        { 
            if ((collision.tag== "Movables" || collision.tag == "Gegner") && (collision.attachedRigidbody))
            {
                TornadoTransition(collision.gameObject, true, tornadoBottom.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((collision.tag == "Movables") || (collision.tag == "Movables")) && (collision.attachedRigidbody))
            TornadoTransition(collision.gameObject, false);
    }

    private void NewTornado()
    {
        tornadoTop = transform.Find("TornadoTop").gameObject;
        tornadokap = new GameObject[1];
        tornadoBottom = transform.Find("TornadoCollider").gameObject;
        firstTornado = this.gameObject;
    }

    void TornadoTransition(GameObject GO, bool State, Transform TopOrBottom)
    {

        if (State && GO) {
            
            Vector2 dir = TopOrBottom.transform.position - GO.transform.position;
            
            GO.GetComponent<Rigidbody2D>().velocity = dir;
            
        }

        else
        {
            if (GO) { }
            
              GO.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,0), ForceMode2D.Impulse);
               
        }
    }

    void TornadoTransition(GameObject GO, bool State)
    {
        if(!State)
        {
           GO.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }
    }


}

